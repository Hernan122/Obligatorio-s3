using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.UsuarioDTO.CRUD;
using Compartido.DTOs.UsuarioDTO;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private CUListadoUsuario CUListadoUsuario = new CUListadoUsuario();
        private CUAltaUsuario CUAltaUsuario = new CUAltaUsuario();
        private CUVerDetalleUsuario CUVerDetalleUsuario = new CUVerDetalleUsuario();
        private CUBajaUsuario CUBajaUsuario = new CUBajaUsuario();
        private CUEditarUsuario CUEditarUsuario = new CUEditarUsuario();
        private CULoginUsuario CULoginUsuario = new CULoginUsuario();

        [HttpGet]
        public IActionResult AltaUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaUsuario(AltaUsuarioViewModel usuario) 
        {
            try
            {
                AltaUsuarioDTO usuarioDTO = new AltaUsuarioDTO()
                {
                    NombreUsuario = usuario.Nombre,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    Rol = usuario.Rol,
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel usuario)
        {
            try
            {
                LoginUsuarioDTO usuarioDTO = new LoginUsuarioDTO()
                {
                    Email = usuario.Email,
                    Password = usuario.Password
                };

                CULoginUsuario.Ejecutar(usuarioDTO);
                ViewBag.Mensaje = "Sesion iniciada con exito";
                return RedirectToAction(nameof(ListadoUsuarios));
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + ", " + e.StackTrace;
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult ListadoUsuarios()
        {
            List<VerUsuarioDTO> usuariosDTO = CUListadoUsuario.Ejecutar();
            List<ListadoUsuarioViewModel> listadoUsuarioViewModel = new List<ListadoUsuarioViewModel>();
            try
            {
                listadoUsuarioViewModel = usuariosDTO.Select(u => new ListadoUsuarioViewModel()
                {
                    Id = u.Id,
                    NombreUsuario = u.NombreUsuario,
                }).ToList();
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + ", " + e.StackTrace;
            }
            return View(listadoUsuarioViewModel);
        }

        [HttpGet]
        public ActionResult VerUsuario(int id)
        {
            VerDetallesUsuarioDTO usuarioDTO = CUVerDetalleUsuario.Ejecutar(id);
            VerDetallesUsuarioViewModel usuarioViewModel;
            try
            {
                usuarioViewModel = new VerDetallesUsuarioViewModel
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.NombreUsuario,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    Rol = usuarioDTO.Rol
                };
                return View(usuarioViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuario(int id)
        {
            VerDetallesUsuarioDTO usuarioDTO = CUVerDetalleUsuario.Ejecutar(id);
            VerDetallesUsuarioViewModel usuarioViewModel;
            try
            {
                usuarioViewModel = new VerDetallesUsuarioViewModel
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.NombreUsuario,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    Rol = usuarioDTO.Rol
                };
                return View(usuarioViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditarUsuario(EditarUsuarioViewModel usuario)
        {
            try
            {
                EditarUsuarioDTO usuarioDTO = new EditarUsuarioDTO
                {
                    Id = usuario.Id,
                    NombreUsuario = usuario.Nombre,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    Rol = usuario.Rol
                };
                CUEditarUsuario.Ejecutar(usuarioDTO);

                ViewBag.Mensaje = "Editado con exito";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return RedirectToAction(nameof(ListadoUsuarios));
        }

        [HttpGet]
        public ActionResult BajaUsuario(int id)
        {
            try
            {
                CUBajaUsuario.Ejecutar(id);
                ViewBag.Mensaje = "Eliminado con exito";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return RedirectToAction(nameof(ListadoUsuarios));
        }
    }
}