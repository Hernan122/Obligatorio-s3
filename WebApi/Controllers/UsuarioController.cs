using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IListadoUsuario CUListadoUsuario { get; set; }
        private IAltaUsuario CUAltaUsuario { get; set; }
        private IVerDetalleUsuario CUVerDetalleUsuario { get; set; }
        private IBajaUsuario CUBajaUsuario { get; set; }
        private IEditarUsuario CUEditarUsuario { get; set; }
        private ILoginUsuario CULoginUsuario { get; set; }

        public UsuarioController(
            IListadoUsuario cuListadoUsuario,
            IAltaUsuario cuAltaUsuario,
            IVerDetalleUsuario cuVerDetalleUsuario,
            IBajaUsuario cuBajaUsuario,
            IEditarUsuario cuEditarUsuario,
            ILoginUsuario cuLoginUsuario
        )
        {
            CUListadoUsuario = cuListadoUsuario;
            CUAltaUsuario = cuAltaUsuario;
            CUVerDetalleUsuario = cuVerDetalleUsuario;
            CUBajaUsuario = cuBajaUsuario;
            CUEditarUsuario = cuEditarUsuario;
            CULoginUsuario = cuLoginUsuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
