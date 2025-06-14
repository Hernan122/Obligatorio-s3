using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;
using MVC.Models.Envio;
using MVC.Models.Envio.Comun;
using MVC.Models.Envio.Urgente;
using MVC.Models.Usuario;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    
    public class EnvioController : ControllerB
    {
        [Login]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ListadoEnvioViewModel> listadoEnviosViewModel = new List<ListadoEnvioViewModel>();
            try
            {
                string url = "https://localhost:7189/api/Envio/FindAll";
                ResHttpViewModel datos = WebApi_Process(url, null);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listadoEnviosViewModel = JsonConvert.DeserializeObject<List<ListadoEnvioViewModel>>(datos.Datos);
                }
                else
                {
                    ViewBag.Mensaje = datos;
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View(listadoEnviosViewModel);
        }

        [Login]
        [HttpGet]
        public IActionResult CrearEnvio()
        {
            return View();
        }

        [Login]
        [HttpGet]
        public IActionResult FormCrearEnvio(string type)
        {
            string param = type;
            try
            {
                if (type == "Comun" || type == "Urgente")
                {
                    string url = $"~/Views/Envio/{param}/Crear.cshtml";
                    return View(url);
                }
                else
                {
                    throw new Exception($"No existe ese tipo de envio: {type}");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                return View(nameof(CrearEnvio));
            }
        }

        [HttpPost]
        public IActionResult CrearEnvioComun(AltaComunViewModel envio)
        {
            string mensaje = "";
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index), new { Mensaje = "Envio Comun creado con exito" });
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException)
            {
                mensaje = "Debe rellenar todos los valores";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                mensaje += e.InnerException;
            }
            ViewBag.MensajeError = mensaje;
            return View($"~/Views/Envio/Comun/Crear.cshtml");
        }

        [HttpPost]
        public IActionResult CrearEnvioUrgente(AltaUrgenteViewModel envio)
        {
            string mensaje;
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index), new { Mensaje = "Envio Urgente creado con exito" });
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException)
            {
                mensaje = "Debe rellenar todos los valores";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            ViewBag.MensajeError = mensaje;
            return View($"~/Views/Envio/Urgente/Crear.cshtml");
        }

        [Login]
        [HttpGet]
        public IActionResult BajaEnvio(int id)
        {
            string mensaje;
            try
            {
                return RedirectToAction(nameof(Index), new { Mensaje = "Eliminado con exito" });
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return RedirectToAction(nameof(Index), new { MensajeError = mensaje });
        }
        
        [HttpGet]
        public IActionResult BuscarEnvioPorNumeroTracking(VerDetallesEnvioYSeguimientosViewModel envio)
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEnvioPorNumeroTracking(string numeroTracking)
        {
            VerDetallesEnvioYSeguimientosViewModel envio = null;
            try
            {
                if (string.IsNullOrEmpty(numeroTracking))
                {
                    throw new ArgumentNullException();
                }
                string url = $"https://localhost:7189/api/Envio/BuscarEnvioPorNumeroTracking/{numeroTracking}";
                ResHttpViewModel datos = WebApi_Process(url, null);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    envio = JsonConvert.DeserializeObject<VerDetallesEnvioYSeguimientosViewModel>(datos.Datos);
                    ViewBag.Mensaje = "Envio Encontrado";
                } 
                else
                {
                    ViewBag.MensajeError = "Envio no Encontrado";
                }
            }
            catch (ArgumentNullException)
            {
                ViewBag.MensajeError = "Ingrese un Numero de Tracking";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View(envio);
        }

        [HttpGet]
        public IActionResult ListadoEnviosDetallados()
        {
            IEnumerable<VerDetallesEnvioYSeguimientosViewModel> listado = new List<VerDetallesEnvioYSeguimientosViewModel>();
            try
            {
                string url = "";
                ResHttpViewModel datos = WebApi_Process(url, (int)HttpContext.Session.GetInt32("Id"), "POST");

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<VerDetallesEnvioYSeguimientosViewModel>>(datos.Datos)
                }
                else
                {
                    ViewBag.MensajeError = datos.Datos;
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View();
        }

    }
}