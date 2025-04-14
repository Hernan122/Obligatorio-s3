// Alta/Registro de usuarios:

// Exception de usuario:
using LogicaNegocio.ExcepcionesEntidades;

using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.UsuarioDTO.CRUD;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private AltaUsuario CUAltaUsuario = new AltaUsuario();
        private ListadoUsuario CUListadoUsuario = new ListadoUsuario();

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioViewModel usuario) 
        {
            try
            {
                AltaUsuarioDTO usuarioDTO = new AltaUsuarioDTO()
                {
                    NombreUsuario = usuario.Nombre,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    Rol = usuario.Rol
                };

                CUAltaUsuario.Ejecutar(usuarioDTO);
                ViewBag.Mensaje = "Usuario agregado";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + ", " + e.StackTrace;
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ListadoUsuarios()
        {
            List<VerUsuarioDTO> usuariosDTO = CUListadoUsuario.Ejecutar();
            List<ListadoUsuarioViewModel> listadoUsuarioViewModel = new List<ListadoUsuarioViewModel>();
            try
            {

                listadoUsuarioViewModel = usuariosDTO.Select(u => new ListadoUsuarioViewModel()
                {
                    Id = u.Id,
                    NombreUsuario = u.NombreUsuario
                }).ToList();
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + ", " + e.StackTrace;
            }
            return View(listadoUsuarioViewModel);
        }

        // CRUD

        public ActionResult AgregarUsuario()
        {
            return null;
        }

        public ActionResult VerUsuario()
        {
            return null;
        }

        public ActionResult ModificarUsuario()
        {
            return null;
        }

        public ActionResult EliminarUsuario()
        {
            return null;
        }

    }
}
