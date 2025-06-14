using Compartido.DTOs.EnvioDTO;
using Compartido.ExcepcionesConflictos;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
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
        private IBuscarEnvioPorNumeroTracking CUBuscarEnvioPorNumeroTracking { get; set; }
        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IBajaEnvio cuBajaEnvio,
            IBuscarEnvioPorId cuBuscarEnvioPorId,
            IBuscarEnvioPorNumeroTracking cuBuscarEnvioPorNumeroTracking
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUBajaEnvio = cuBajaEnvio;
            CUBuscarEnvioPorId = cuBuscarEnvioPorId;
            CUBuscarEnvioPorNumeroTracking = cuBuscarEnvioPorNumeroTracking;
        }


        // GET: api/<EnvioController>
        [HttpGet("FindAll")]
        public IActionResult Get()
        {
            try
            {
                List<ListadoEnvioDTO> datoEnvios = CUListadoEnvio.Ejecutar();
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
                VerDetallesEnvioYSeguimientosDTO dto = CUBuscarEnvioPorNumeroTracking.Ejecutar(numeroTracking);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPost("ListadoEnviosDetallados")]
        public IActionResult ListadoEnviosDetallados([FromBody] int id)
        {
            try
            {
                CULi
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}