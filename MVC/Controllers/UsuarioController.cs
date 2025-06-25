using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;
using MVC.Models.Usuario;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class UsuarioController : ControllerB
    {

        public UsuarioController(IConfiguration configuration)
        {
            urlBase = configuration.GetValue<string>("urlBase")+"/Usuario";
        }

        [Login]
        [Administrador]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                ResHttpViewModel datos = WebApi_Process(urlBase+"/FindAll");

                List<ListadoUsuarioViewModel> listado = JsonConvert.DeserializeObject<List<ListadoUsuarioViewModel>>(datos.Datos) ?? [];
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
            catch (ArgumentNullException)
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
                if (ModelState.IsValid)
                {
                    //ResHttpViewModel datos = WebApi_Process(urlBase+"/IniciarSesion", usuario, "POST");

                    HttpClient cliente = new HttpClient();
                    Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(urlBase+"/IniciarSesion", usuario);
                    HttpResponseMessage respuesta = tarea.Result;

                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        InformacionUsuarioLogueadoViewModel user = JsonConvert.DeserializeObject<InformacionUsuarioLogueadoViewModel>(datos)
                            ?? throw new Exception("Error desconocido");

                        HttpContext.Session.SetString("Token", user.Token);

                        cliente.DefaultRequestHeaders.Authorization = new
                        AuthenticationHeaderValue("Bearer", user.Token);

                        HttpContext.Session.SetInt32("Id", user.Id);
                        HttpContext.Session.SetString("Rol", user.Rol);

                        HttpContext.Session.SetString("Email", usuario.Email);
                        HttpContext.Session.SetString("ActualPassword", usuario.Password);

                        if (HttpContext.Session.GetString("Rol") != RolUsuario.Cliente.ToString())
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
                        ViewBag.MensajeError = datos;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
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
            VerDetallesUsuarioViewModel? usuarioViewModel = null;
            try
            {
                ResHttpViewModel datos = WebApi_Process(urlBase+$"/{id}");
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
            VerDetallesUsuarioViewModel? usuarioViewModel = null;
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
                ResHttpViewModel datos = WebApi_Process(urlBase+"?usuarioId="+id+"&funcionarioId="+(int)HttpContext.Session.GetInt32("Id"), null, "DELETE");
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
                    throw new ArgumentNullException();

                if (actualPassword != HttpContext.Session.GetString("ActualPassword"))
                    throw new Exception("Contraseña actual no coincide");

                int usuarioId = (int)HttpContext.Session.GetInt32("Id");
                ResHttpViewModel datos = WebApi_Process_WithAuthentication(urlBase+"/CambiarPassword/"+(int)HttpContext.Session.GetInt32("Id"), newPassword, "PUT");
                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = datos.Datos;
                    HttpContext.Session.SetString("ActualPassword", newPassword);
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