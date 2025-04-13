// Alta/Registro de usuarios:
using Compartido.DTOs.UsuarioDTO;

// Exception de usuario:
using LogicaNegocio.ExcepcionesEntidades;

using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

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
            List<ListadoUsuarioDTO> usuariosDTO = CUListadoUsuario.Ejecutar();
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

        //private IAltaUsuario CUAltaUsuario { get; set; }
    }
}
