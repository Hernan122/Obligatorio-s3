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

        //[HttpGet("FindById/{id}", Name = "FindById")]
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