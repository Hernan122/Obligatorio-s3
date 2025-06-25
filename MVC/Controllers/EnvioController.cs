using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;
using MVC.Models.Envio;
using MVC.Models.Envio.Comun;
using MVC.Models.Envio.Urgente;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class EnvioController : ControllerB
    {

        public EnvioController(IConfiguration configuration)
        {
            urlBase = configuration.GetValue<string>("urlBase")+"/Envio";
        }

        [Login]
        [Administrador]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ListadoEnviosViewModel> listadoEnviosViewModel = [];
            try
            {
                ResHttpViewModel datos = WebApi_Process_WithAuthentication(urlBase+"/FindAll");
                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listadoEnviosViewModel = JsonConvert.DeserializeObject<List<ListadoEnviosViewModel>>(datos.Datos) ?? [];
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
            return View(listadoEnviosViewModel);
        }

        [Login]
        [HttpGet]
        public IActionResult CrearEnvio()
        {
            return View();
        }

        [Login]
        [Administrador]
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

        // -------------------- Obligatorio 2 --------------------
        // RF1
        [HttpGet]
        public IActionResult BuscarEnvioPorNumeroTracking(ListadoEnviosDetalladosViewModel envio)
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEnvioPorNumeroTracking(string numeroTracking)
        {
            ListadoEnviosViewModel? envio = null;
            try
            {
                if (string.IsNullOrEmpty(numeroTracking))
                    throw new ArgumentNullException();

                // Envio
                ResHttpViewModel datos = WebApi_Process(urlBase+"/BuscarEnvioPorNumeroTracking/"+numeroTracking);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    envio = JsonConvert.DeserializeObject<ListadoEnviosViewModel>(datos.Datos)
                        ?? throw new Exception("Error desconocido");

                    ViewBag.Mensaje = "Envio Encontrado";

                    ResHttpViewModel datos2 = WebApi_Process(urlBase+"/ListadoSeguimientos/"+envio.Id);

                    if (datos2.Respuesta.IsSuccessStatusCode)
                    {
                        IEnumerable<ListadoSeguimientosViewModel> seguimientos = JsonConvert.DeserializeObject<List<ListadoSeguimientosViewModel>>(datos2.Datos) ?? [];
                        if (seguimientos.Any())
                        {
                            ViewBag.Seguimientos = seguimientos;
                        }
                    }
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

        // RF4
        [Login]
        [Cliente]
        [HttpGet]
        public IActionResult ListadoEnviosDetallados()
        {
            IEnumerable<ListadoEnviosDetalladosViewModel> listado = [];
            try
            {
                HttpContext.Session.GetInt32("Id");

                int usuarioId = (int)HttpContext.Session.GetInt32("Id");
                ResHttpViewModel datos = WebApi_Process_WithAuthentication(urlBase+"/ListadoEnviosDetallados/"+usuarioId);
                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoEnviosDetalladosViewModel>>(datos.Datos) ?? [];
                    if (!listado.Any())
                    {
                        ViewBag.MensajeError = "Cliente no tiene envios";
                    }
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
            return View(listado);
        }

        // RF4
        [Login]
        [Cliente]
        [HttpGet]
        public IActionResult ListadoSeguimientos(int envioId)
        {
            IEnumerable<ListadoSeguimientosViewModel> listado = [];
            try
            {
                ResHttpViewModel datos = WebApi_Process_WithAuthentication(urlBase+"/ListadoSeguimientos/"+envioId);
                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoSeguimientosViewModel>>(datos.Datos) ?? [];
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
            return View(listado);
        }

        // RF5
        [Login]
        [Cliente]
        [HttpGet]
        public IActionResult BuscarEnvioPorFechas(IEnumerable<ListadoEnvioInfoRelevanteViewModel> pListado)
        {
            return View(pListado);
        }

        // RF5
        [HttpPost]
        public IActionResult BuscarEnvioPorFechas(DateOnly fechaInicio, DateOnly fechaFin, int estadoEnvio)
        {
            IEnumerable<ListadoEnvioInfoRelevanteViewModel> listado = [];
            try
            {
                DateOnly fechaVacia = new DateOnly();
                if (fechaInicio == fechaVacia) 
                    throw new ArgumentNullException();

                if (fechaFin == fechaVacia) 
                    throw new ArgumentNullException();

                BuscarEnvioPorFechasViewModel envio = new()
                {
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                };
                ResHttpViewModel datos = WebApi_Process_WithAuthentication(urlBase+"/BuscarEnvioPorFechas/"+estadoEnvio, envio, "POST");

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoEnvioInfoRelevanteViewModel>>(datos.Datos) ?? [];
                    if (!listado.Any())
                    {
                        ViewBag.MensajeError = "No hay Envios";
                    }
                } else
                {
                    ViewBag.MensajeError = datos.Datos;
                }
            }
            catch (ArgumentNullException)
            {
                ViewBag.MensajeError = "Ingrese fechas validas";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View(listado);
        }

        // RF6
        [Login]
        [Cliente]
        [HttpGet]
        public IActionResult BuscarEnvioPorComentario(IEnumerable<ListadoEnviosViewModel> pListado)
        {
            return View(pListado);
        }

        // RF6
        [HttpPost]
        public IActionResult BuscarEnvioPorComentario(string comentario)
        {
            IEnumerable<ListadoEnviosViewModel> listado = [];
            try
            {
                if (string.IsNullOrEmpty(comentario))
                    throw new ArgumentNullException();

                ResHttpViewModel datos = WebApi_Process_WithAuthentication(urlBase+"/BuscarEnvioPorComentario/"+comentario);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoEnviosViewModel>>(datos.Datos) ?? [];
                    if (!listado.Any())
                    {
                        ViewBag.MensajeError = "No hay Envios";
                    }
                }
                else
                {
                    ViewBag.MensajeError = datos.Datos;
                }
            }
            catch (ArgumentNullException)
            {
                ViewBag.MensajeError = "Ingrese un comentario";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View(listado);
        }
    }
}