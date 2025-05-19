using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.UsuarioDTO;
using MVC.Models.Usuario;
using Microsoft.AspNetCore.Http;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using System.Security.Cryptography.Xml;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.ExcepcionesConflictos;

namespace MVC.Controllers
{

    public class UsuarioController : Controller
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

        [HttpGet]
        public ActionResult Index(string mensaje, string mensajeError)
        {
            //var rol = HttpContext.Session.GetString("Rol");
            //if (rol != "Administrador")
            //{
            //    return RedirectToAction("Login");
            //}

            ViewBag.Mensaje = mensaje;
            ViewBag.MensajeError = mensajeError;

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
        public ActionResult AltaUsuario(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
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
                    return RedirectToAction(nameof(AltaUsuario), new { Mensaje = "Usuario agregado" });
                }
                else
                {
                    throw new ArgumentNullException("Debe rellenar todos los valores");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
                ViewBag.MensajeError += ", " + e.InnerException;
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

                InformacionUsuarioLogueadoViewModelDTO buscarUsuario = CULoginUsuario.Ejecutar(usuarioDTO);

                InformacionUsuarioLogueadoViewModel usuarioLogueado = new InformacionUsuarioLogueadoViewModel()
                {
                    Id = buscarUsuario.Id,
                    Rol = buscarUsuario.Rol
                };

                HttpContext.Session.SetInt32("Id", usuarioLogueado.Id);
                HttpContext.Session.SetString("Rol", usuarioLogueado.Rol);
                ViewBag.Mensaje = "Sesion iniciada con exito";

                if (HttpContext.Session.GetString("rol") == "Administrador")
                {
                    return RedirectToAction(nameof(Index), "Usuario");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
                return View();
            }
        }

        [HttpGet]
        public ActionResult VerDetallesUsuario(int id)
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
            VerDetallesUsuarioViewModel usuarioViewModel = null;
            try
            {
                if (id < 0)
                {
                    throw new UsuarioException("Id incorrecto");
                }
                VerDetallesUsuarioDTO usuarioDTO = CUVerDetalleUsuario.Ejecutar(id);
                usuarioViewModel = new VerDetallesUsuarioViewModel()
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.NombreUsuario,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    //Rol = usuarioDTO.Rol
                };
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return View(usuarioViewModel);
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
                        //Rol = usuario.Rol
                    };
                    CUEditarUsuario.Ejecutar(usuarioDTO);
                    ViewBag.Mensaje = "Editado con exito";
                    return RedirectToAction(nameof(Index), new { Mensaje = "Editado con exito" });
                }
                else
                {
                    throw new ArgumentNullException("Algunos valores no son correctos");
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message + ", ";
                //mensaje += e.StackTrace;
                mensaje += e.InnerException;
                return RedirectToAction(nameof(Index), new { MensajeError = mensaje });
            }
        }

        [HttpGet]
        public ActionResult BajaUsuario(int id)
        {
            int idActual = (int)HttpContext.Session.GetInt32("Id");
            try
            {
                if (id == idActual)
                {
                    throw new ConflictException("No puedes eliminarte a ti mismo");
                }
                CUBajaUsuario.Ejecutar(id);
                ViewBag.Mensaje = "Eliminado con exito";
                return RedirectToAction(nameof(Index), new { Mensaje = "Eliminado con exito" });
            }
            catch (ConflictException e)
            {
                return RedirectToAction(nameof(Index), new { MensajeError = e.Message});
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { MensajeError = e.Message });
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}