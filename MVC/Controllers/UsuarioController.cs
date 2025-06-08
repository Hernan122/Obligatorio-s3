using Microsoft.AspNetCore.Mvc;
using Compartido.DTOs.UsuarioDTO;
using MVC.Models.Usuario;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.DTOs.AuditoriaDTO;
using MVC.Filters;
using MVC.Models.Envio;

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

        [Login]
        [HttpGet]
        public ActionResult Index(string mensaje, string mensajeError)
        {
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

                if (listadoUsuarioViewModel.Count() == 0)
                {
                    ViewBag.MensajeError = "No hay usuarios";
                }

                return View(listadoUsuarioViewModel);
            }
            catch (Exception e)
            {
                return View(new List<ListadoUsuarioViewModel>());
            }
        }

        [Login]
        [HttpGet]
        public ActionResult AltaUsuario(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [Login]
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
                        Rol = usuario.Rol
                    };
                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                    {
                        AccionRealizada = Accion.Agregado.ToString(),
                        Fecha = DateTime.Now,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id")
                    };

                    CUAltaUsuario.Ejecutar(usuarioDTO, auditoriaDTO);
                    return RedirectToAction(nameof(AltaUsuario), new { Mensaje = "Usuario agregado" });
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException e)
            {
                ViewBag.MensajeError = "Debe rellenar todos los valores";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
                //ViewBag.MensajeError += e.InnerException;
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

        [Login]
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

        [Login]
        [HttpGet]
        public ActionResult EditarUsuario(int id)
        {
            VerDetallesUsuarioViewModel usuarioViewModel = null;
            string mensaje = "";
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
                };
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                mensaje += e.StackTrace;
                mensaje += e.InnerException;
                ViewBag.MensajeError = mensaje;
            }
            return View(usuarioViewModel);
        }

        [HttpPost]
        public ActionResult EditarUsuario(EditarUsuarioViewModel usuario)
        {
            string mensaje;
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
                    };
                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO
                    {
                        AccionRealizada = Accion.Editado.ToString(),
                        Fecha = DateTime.Now,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id")
                    };

                    CUEditarUsuario.Ejecutar(usuarioDTO, auditoriaDTO);
                    return RedirectToAction(nameof(Index), new { Mensaje = "Editado con exito" });
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException)
            {
                mensaje = "Algunos valores no son correctos";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                mensaje += e.StackTrace;
                mensaje += e.InnerException;
            }
            return RedirectToAction(nameof(Index), new { MensajeError = mensaje });
        }

        [HttpGet]
        public ActionResult BajaUsuario(int id)
        {
            string mensaje;
            try
            {
                if (id == (int)HttpContext.Session.GetInt32("Id"))
                {
                    throw new UsuarioException("No puedes eliminarte a ti mismo");
                }

                AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                {
                    AccionRealizada = Accion.Eliminado.ToString(),
                    Fecha = DateTime.Now,
                    FuncionarioId = (int)HttpContext.Session.GetInt32("Id")
                };

                CUBajaUsuario.Ejecutar(id, auditoriaDTO);

                mensaje = "Eliminado con exito";
                return RedirectToAction(nameof(Index), new { Mensaje = mensaje });
            }
            catch (Exception e)
            {
                mensaje = e.InnerException.ToString();
                //mensaje += e.Message;
                return RedirectToAction(nameof(Index), new { MensajeError = mensaje });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}