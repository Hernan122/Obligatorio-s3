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

        [HttpGet("FindAll")]
        public IActionResult Get()
        {
            try
            {
                List<ListadoEnvioDTO> datoEnvios = CUListadoEnvio.Ejecutar();
                if (datoEnvios == null || datoEnvios.Count == 0)
                {
                    return NotFound("No existen carreras");
                }
                else
                {
                    return Ok(datoEnvios);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("FindById/{id}", Name = "FindById")]
        //[HttpGet("FindById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id recibido no es correcto");
                }
                VerDetallesEnvioDTO dto = CUBuscarEnvioPorId.Ejecutar(id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("FindByNumeroTracking/{numeroTracking}")]
        public IActionResult FindByNumeroTracking(string numeroTracking)
        {
            try
            {
                VerDetallesEnvioDTO dto = CUBuscarEnvioPorNumeroTracking.Ejecutar(numeroTracking);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}