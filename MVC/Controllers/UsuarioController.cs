using Microsoft.AspNetCore.Mvc;
using MVC.Models.Usuario;
using Newtonsoft.Json;
using MVC.Models;
using MVC.Filters;
using System.Security.Policy;

namespace MVC.Controllers
{
    public class UsuarioController : ControllerB
    {
        [Login]
        [Administrador]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                string url = "https://localhost:7189/api/Usuario/FindAll";
                ResHttpViewModel datos = WebApi_Process(url, null);

                List<ListadoUsuarioViewModel> listado = JsonConvert.DeserializeObject<List<ListadoUsuarioViewModel>>(datos.Datos);
                return View(listado);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View(new List<ListadoUsuarioViewModel>());
        }

        [Login]
        [Administrador]
        [HttpGet]
        public IActionResult AltaUsuario(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult AltaUsuario(AltaUsuarioViewModel usuario) 
        {
            try
            {
                if (ModelState.IsValid)
                {
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
            }
            return View();
        }

        // RF2
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // RF2
        [HttpPost]
        public IActionResult Login(LoginUsuarioViewModel usuario)
        {
            try
            {
                if (usuario.Email == null || usuario.Password == null)
                {
                    throw new ArgumentNullException();
                }
                string url = "https://localhost:7189/api/Usuario/IniciarSesion";
                ResHttpViewModel datos = WebApi_Process(url, usuario, "POST");

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    InformacionUsuarioLogueadoViewModel user = JsonConvert.DeserializeObject<InformacionUsuarioLogueadoViewModel>(datos.Datos);
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("Rol", user.Rol);
                    HttpContext.Session.SetString("ActualPassword", usuario.Password);

                    if (user.Rol != RolUsuario.Cliente.ToString())
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return Redirect("Home/Index");
                    }
                }
                else
                {
                    ViewBag.MensajeError = datos.Datos;
                }
            }
            catch (ArgumentNullException e)
            {
                ViewBag.MensajeError = "Debe rellenar todos los campos";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult VerDetallesUsuario(int id)
        {
            VerDetallesUsuarioViewModel usuarioViewModel = null;
            try
            {
                string url = "https://localhost:7189/api/Usuario/"+id;
                ResHttpViewModel datos = WebApi_Process(url, null);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    usuarioViewModel = JsonConvert.DeserializeObject<VerDetallesUsuarioViewModel>(datos.Datos);
                    ViewBag.Mensaje = datos.Respuesta;
                }
                else
                {
                    ViewBag.MensajeError = "Error al obtener datos";    
                }

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
        public IActionResult EditarUsuario(int id)
        {
            VerDetallesUsuarioViewModel usuarioViewModel = null;
            string mensaje = "";
            try
            {
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
        public IActionResult EditarUsuario(EditarUsuarioViewModel usuario)
        {
            string mensaje;
            try
            {
                if (ModelState.IsValid)
                {
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
        public IActionResult BajaUsuario(int id)
        {
            try
            {
                string url = $"https://localhost:7189/api/Usuario?usuarioId={id}&funcionarioId={(int)HttpContext.Session.GetInt32("Id")}";
                ResHttpViewModel datos = WebApi_Process(url, null, "DELETE");
                
                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), 
                        new { Mensaje = "Eliminado con exito" });
                }
                else
                {
                    return RedirectToAction(nameof(Index),
                        new { MensajeError = "No se pudo eliminar" });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), 
                    new { MensajeError = e.InnerException.ToString() });
            }
        }

        // RF2
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // RF3
        [Login]
        [HttpGet]
        public IActionResult CambiarPassword()
        {
            return View();
        }

        // RF3
        [HttpPost]
        public IActionResult CambiarPassword(string actualPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(actualPassword) || string.IsNullOrEmpty(newPassword))
                {
                    throw new ArgumentNullException();
                }

                if (actualPassword != HttpContext.Session.GetString("ActualPassword"))
                {
                    throw new Exception("Contraseña actual no coincide");
                }
                string url = "https://localhost:7189/api/Usuario/CambiarPassword/"+(int)HttpContext.Session.GetInt32("Id");
                ResHttpViewModel datos = WebApi_Process(url, newPassword, "PUT");

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = datos.Datos;
                }
                else
                {
                    ViewBag.MensajeError = datos.Datos;
                }
            }
            catch (ArgumentNullException)
            {
                ViewBag.MensajeError = "Debe rellenar todos los campos";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View();
        }
    }
}