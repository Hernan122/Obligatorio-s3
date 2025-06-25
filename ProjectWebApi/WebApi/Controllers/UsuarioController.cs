using Compartido.DTOs.AuditoriaDTO;
using Compartido.DTOs.UsuarioDTO;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.JWT;

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
        private ICambiarPassword CUCambiarPassword { get; set; }

        public UsuarioController(
            IListadoUsuario cuListadoUsuario,
            IAltaUsuario cuAltaUsuario,
            IVerDetalleUsuario cuVerDetalleUsuario,
            IBajaUsuario cuBajaUsuario,
            IEditarUsuario cuEditarUsuario,
            ILoginUsuario cuLoginUsuario,
            ICambiarPassword cuCambiarPassword
        )
        {
            CUListadoUsuario = cuListadoUsuario;
            CUAltaUsuario = cuAltaUsuario;
            CUVerDetalleUsuario = cuVerDetalleUsuario;
            CUBajaUsuario = cuBajaUsuario;
            CUEditarUsuario = cuEditarUsuario;
            CULoginUsuario = cuLoginUsuario;
            CUCambiarPassword = cuCambiarPassword;
        }

        /// <summary>
        /// Permite listar todos los usuarios (no eliminados) a excepción de los administradores.
        /// </summary>
        /// <returns></returns>
        // GET api/<UsuarioController>/5
        [HttpGet("FindAll")]
        public IActionResult Get()
        {
            try
            {
                List<ListadoUsuarioDTO> listado = CUListadoUsuario.Ejecutar();
                return Ok(listado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite buscar usuarios por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                VerDetallesUsuarioDTO dto = CUVerDetalleUsuario.Ejecutar(id);
                return Ok(dto);
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite iniciar sesion
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        // POST api/<UsuarioController>
        [HttpPost("IniciarSesion")]
        public IActionResult Post([FromBody] LoginUsuarioDTO usuario)
        {
            try
            {
                LoginUsuarioDTO dto = new()
                {
                    Email = usuario.Email,
                    Password = usuario.Password
                };
                InformacionUsuarioLogueadoDTO user = CULoginUsuario.Ejecutar(dto);
                user.Token = ManejadorToken.CrearToken(user);
                return Ok(user);
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Permite crear usuario
        /// </summary>
        /// <param name="funcionarioId"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        // POST api/<UsuarioController>
        [HttpPost("CrearUsuario")]
        public IActionResult Post(int funcionarioId, [FromBody] AltaUsuarioDTO usuario)
        {
            try
            {
                AuditoriaDTO auditoriaDTO = new()
                {
                    AccionRealizada = Accion.Agregado.ToString(),
                    Fecha = DateTime.Now,
                    FuncionarioId = funcionarioId
                };
                CUAltaUsuario.Ejecutar(usuario, auditoriaDTO);
                return Ok();
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite cambiar la contraseña de un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // PUT api/<UsuarioController>/5
        [Authorize]
        [HttpPut("CambiarPassword/{id}")]
        public IActionResult Put(int id, [FromBody] string password)
        {
            try
            {
                CUCambiarPassword.Ejecutar(id, password);
                return Ok("Actualizado correctamente");
            }
            catch (UsuarioException e)
            {
                return BadRequest("Error al cambiar contraseña: " + e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error Interno: " + e.Message);
            }
        }

        /// <summary>
        /// Permite borrar un usuario
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="funcionarioId"></param>
        /// <returns></returns>
        // DELETE api/<UsuarioController>/5
        [HttpDelete]
        public IActionResult Delete(int usuarioId, int funcionarioId)
        {
            try
            {
                AuditoriaDTO auditoriaDTO = new()
                {
                    AccionRealizada = Accion.Eliminado.ToString(),
                    Fecha = DateTime.Now,
                    FuncionarioId = funcionarioId
                };
                CUBajaUsuario.Ejecutar(usuarioId, auditoriaDTO);
                return Ok("Eliminado exitosamente");
            }
            catch (UsuarioException e)
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
