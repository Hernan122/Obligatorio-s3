using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.UsuarioDTO.CRUD;
using Compartido.DTOs.UsuarioDTO;
using MVC.Models.Usuario;
using Microsoft.AspNetCore.Http;

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
                if (ModelState.IsValid)
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

                LoginUsuarioDTO usuarioLogueado = CULoginUsuario.Ejecutar(usuarioDTO);

                HttpContext.Session.SetString("Rol", usuarioLogueado.Rol);
                ViewBag.Mensaje = "Sesion iniciada con exito";

                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    return RedirectToAction(nameof(ListadoUsuarios), "Usuario");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
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
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Administrador")
            {
                return RedirectToAction("Login");
            }

            try
            {
                var usuariosDTO = CUListadoUsuario.Ejecutar();
                var listadoUsuarioViewModel = usuariosDTO.Select(u => new ListadoUsuarioViewModel()
                {
                    Id = u.Id,
                    NombreUsuario = u.NombreUsuario,
                }).ToList();

                return View(listadoUsuarioViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + ", " + e.StackTrace;
                return View(new List<ListadoUsuarioViewModel>());
            }
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
                if (ModelState.IsValid)
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

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}