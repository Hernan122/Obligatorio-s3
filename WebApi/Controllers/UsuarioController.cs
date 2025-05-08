using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IListadoUsuario CUListadoUsuario { get; set; }
        public IAltaUsuario CUAltaUsuario { get; set }

        // GET: api/<UsuarioController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IActionResult Get()
        {
            //return Ok();
            try
            {
                List<ListadoUsuarioDTO> datosUsuarios = CUListadoUsuario.Ejecutar();
                if (datosUsuarios == null || datosUsuarios.Count == 0)
                {
                    return NotFound("No existen usuarios");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}", Name = "FindById")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El Id recibido no es valido");
                }
                return Ok(CUBuscarUsuario.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }
                CUAltaUsuario.Ejecutar(usuarioDTO)
                return CreateAtRoute("FindById", new { Id = usuarioDTO.Id, usuarioDTO });
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message);
            }
            catch (ConflictException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e) 
            {
                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        public IActionResult Update()
        {

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id es incorrecto");
                }
                CUEliminarUsuario.Ejecutar(id);
                return NoContent("El usuario se eliminó correctamente");
            }
            catch (UsuarioException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("/BuscarUsuario/{nombre}")]
        public IActionResult FindByName(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    return BadRequest("Nombre vacio");
                }
                return Ok(CUBuscarUsuarioPorNombre.Ejecutar(nombre));
            }
            catch (UsuarioException e)
            {
                return NotFound("No se encontró un usuario con ese nombre");
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
