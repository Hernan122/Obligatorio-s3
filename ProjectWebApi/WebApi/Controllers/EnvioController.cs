using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private IListadoEnvio CUListadoEnvio { get; set; }
        private IAltaEnvio CUAltaEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private ICambiarEstadoEnvio CUCambiarEstadoEnvio { get; set; }
        private IBuscarEnvioPorId CUBuscarEnvioPorId { get; set; }

        // RF1
        private IBuscarEnvioPorNumeroTracking CUBuscarEnvioPorNumeroTracking { get; set; }

        // RF4
        private IListadoEnviosDetallados CUListadoEnviosDetallados { get; set; }
        private IListadoSeguimientos CUListadoSeguimientos { get; set; }

        // RF5
        private IBuscarEnvioPorFechas CUBuscarEnvioPorFechas { get; set; }

        // RF6
        private IBuscarEnvioPorComentario CUBuscarEnvioPorComentario { get; set; }

        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IBajaEnvio cuBajaEnvio,
            IBuscarEnvioPorId cuBuscarEnvioPorId,
            IBuscarEnvioPorNumeroTracking cuBuscarEnvioPorNumeroTracking,
            IListadoEnviosDetallados cuListadoEnviosDetallados,
            IListadoSeguimientos cuListadoSeguimientos,
            IBuscarEnvioPorFechas cuBuscarEnvioPorFechas,
            IBuscarEnvioPorComentario cuBuscarEnvioPorComentario
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUBajaEnvio = cuBajaEnvio;
            CUBuscarEnvioPorId = cuBuscarEnvioPorId;
            CUBuscarEnvioPorNumeroTracking = cuBuscarEnvioPorNumeroTracking;
            CUListadoEnviosDetallados = cuListadoEnviosDetallados;
            CUListadoSeguimientos = cuListadoSeguimientos;
            CUBuscarEnvioPorFechas = cuBuscarEnvioPorFechas;
            CUBuscarEnvioPorComentario = cuBuscarEnvioPorComentario;
        }

        /// <summary>
        /// Permite listar todos los envios
        /// </summary>
        /// <returns></returns>
        // GET: api/<EnvioController>
        [Authorize]
        [HttpGet("FindAll")]
        public IActionResult Get()
        {
            try
            {
                List<ListadoEnviosDTO> datoEnvios = CUListadoEnvio.Ejecutar();
                if (datoEnvios == null || datoEnvios.Count == 0)
                {
                    return NotFound("No hay envios");
                }
                else
                {
                    return Ok(datoEnvios);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite buscar un envio por su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("FindEnvioById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("El id recibido no es correcto");
                }
                VerDetallesEnvioDTO dto = CUBuscarEnvioPorId.Ejecutar(id);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        /// <summary>
        /// Permite buscar un envio por su numero de tracking
        /// </summary>
        /// <param name="numeroTracking"></param>
        /// <returns></returns>
        [HttpGet("BuscarEnvioPorNumeroTracking/{numeroTracking}")]
        public IActionResult FindByNumeroTracking(string numeroTracking)
        {
            try
            {
                ListadoEnviosDetalladosDTO dto = CUBuscarEnvioPorNumeroTracking.Ejecutar(numeroTracking);
                return Ok(dto);
            }
            catch (EnvioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite buscar los envios de un cliente mediante el Id de este ultimo. Esto devolvera una lista de envios con toda su información
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("ListadoEnviosDetallados/{clienteId}")]
        public IActionResult ListadoEnviosDetallados(int clienteId)
        {
            try
            {
                IEnumerable<ListadoEnviosDetalladosDTO> listado = CUListadoEnviosDetallados.Ejecutar(clienteId);
                return Ok(listado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Permite buscar los seguimientos de un envio
        /// </summary>
        /// <param name="envioId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("ListadoSeguimientos/{envioId}")]
        public IActionResult ListadoSeguimientos(int envioId)
        {
            try
            {
                IEnumerable<ListadoSeguimientosDTO> listado = CUListadoSeguimientos.Ejecutar(envioId);
                return Ok(listado);
            }
            catch (EnvioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite buscar un envio por fechas y estado. Este ultimo es opcional
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="envio"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("BuscarEnvioPorFechas/{estado}")]
        public IActionResult BuscarEnvioPorFechas(int estado, [FromBody] BuscarEnvioPorFechasDTO envio)
        {
            try
            {
                IEnumerable<ListadoEnviosInfoRelevanteDTO> listado = CUBuscarEnvioPorFechas.Ejecutar(estado, envio);
                return Ok(listado);
            }
            catch (EnvioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite buscar un envio por comentario del mismo
        /// </summary>
        /// <param name="comentario"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("BuscarEnvioPorComentario/{comentario}")]
        public IActionResult BuscarEnvioPorComentario(string comentario)
        {
            try
            {
                IEnumerable<ListadoEnviosDTO> listado = CUBuscarEnvioPorComentario.Ejecutar(comentario);
                return Ok(listado);
            }
            catch (EnvioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}