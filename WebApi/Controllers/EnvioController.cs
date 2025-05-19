using Compartido.DTOs.EnvioDTO;
using Compartido.ExcepcionesConflictos;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private IListadoEnvio CUListadoEnvio { get; set; }
        private IAltaEnvio CUAltaEnvio { get; set; }
        private IVerDetallesEnvio CUVerDetallesEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private IEditarEnvio CUEditarEnvio { get; set; }
        private IBuscarEnvio CUBuscarEnvio { get; set; }
        private ICambiarEstadoEnvio CUCambiarEstadoEnvio { get; set; }
        private IObtenerEnvioPorTracking CUObtenerEnvioPorNumeroTracking { get; set; }
        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IVerDetallesEnvio cuVerDetallesEnvio,
            IBajaEnvio cuBajaEnvio,
            IEditarEnvio cuEditarEnvio,
            IBuscarEnvio cuBuscarEnvio,
            IObtenerEnvioPorTracking cuObtenerEnvioPorNumeroTracking
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUVerDetallesEnvio = cuVerDetallesEnvio;
            CUBajaEnvio = cuBajaEnvio;
            CUEditarEnvio = cuEditarEnvio;
            CUBuscarEnvio = cuBuscarEnvio;
            CUObtenerEnvioPorNumeroTracking = cuObtenerEnvioPorNumeroTracking;
        }

        // GET: api/<EnvioController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
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

        //// GET api/<EnvioController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/<CarreraController>/5
        [HttpGet("{id}", Name = "FindById")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id recibido no es correcto");
                }
                return Ok(CUBuscarEnvio.Ejecutar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<CarreraController>/5
        [HttpGet("BuscarPorNumeroTracking/{numeroTracking}")]
        public IActionResult FindByNumeroTracking(int numeroTracking)
        {
            try
            {
                return Ok(CUObtenerEnvioPorNumeroTracking.Ejecutar(numeroTracking));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<EnvioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnvioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnvioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
