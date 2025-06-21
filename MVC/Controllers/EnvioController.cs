using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;
using MVC.Models.Envio;
using MVC.Models.Envio.Comun;
using MVC.Models.Envio.Urgente;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MVC.Controllers
{
    
    public class EnvioController : ControllerB
    {
        [Login]
        [Administrador]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ListadoEnviosViewModel> listadoEnviosViewModel = new List<ListadoEnviosViewModel>();
            try
            {
                string url = "https://localhost:7189/api/Envio/FindAll";
                ResHttpViewModel datos = WebApi_Process(url);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listadoEnviosViewModel = JsonConvert.DeserializeObject<List<ListadoEnviosViewModel>>(datos.Datos);
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
        public IActionResult BuscarEnvioPorNumeroTracking(ListadoEnviosDetalladosViewModel envio)
        {
            return View();
        }

        // -------------------- Obligatorio 2 --------------------
        // RF1
        [HttpPost]
        public IActionResult BuscarEnvioPorNumeroTracking(string numeroTracking)
        {
            ListadoEnviosViewModel envio = null;
            try
            {
                if (string.IsNullOrEmpty(numeroTracking))
                {
                    throw new ArgumentNullException();
                }

                // Envio
                string url = $"https://localhost:7189/api/Envio/BuscarEnvioPorNumeroTracking/{numeroTracking}";
                ResHttpViewModel datos = WebApi_Process(url);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    envio = JsonConvert.DeserializeObject<ListadoEnviosViewModel>(datos.Datos);
                    ViewBag.Mensaje = "Envio Encontrado";

                    string url2 = $"https://localhost:7189/api/Envio/ListadoSeguimientos/" + envio.Id;
                    ResHttpViewModel datos2 = WebApi_Process(url2);

                    if (datos2.Respuesta.IsSuccessStatusCode)
                    {
                        IEnumerable<ListadoSeguimientosViewModel> seguimientos = null;
                        seguimientos = JsonConvert.DeserializeObject<List<ListadoSeguimientosViewModel>>(datos2.Datos);

                        if (seguimientos.Count() != 0)
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
            IEnumerable<ListadoEnviosDetalladosViewModel> listado = new List<ListadoEnviosDetalladosViewModel>();
            try
            {
                string url = "https://localhost:7189/api/Envio/ListadoEnviosDetallados/" + (int)HttpContext.Session.GetInt32("Id");
                ResHttpViewModel datos = WebApi_Process(url);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoEnviosDetalladosViewModel>>(datos.Datos);
                    if (listado.Count() == 0)
                    {
                        ViewBag.MensajeError = "Cliente no tiene envios";
                        listado = new List<ListadoEnviosDetalladosViewModel>();
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
            IEnumerable<ListadoSeguimientosViewModel> listado = new List<ListadoSeguimientosViewModel>();
            try
            {
                string url = "https://localhost:7189/api/Envio/ListadoSeguimientos/" + envioId;
                ResHttpViewModel datos = WebApi_Process(url);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoSeguimientosViewModel>>(datos.Datos);
                    if (listado.Count() == 0)
                    {
                        listado = new List<ListadoSeguimientosViewModel>();
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
        public IActionResult BuscarEnvioPorFechas(DateTime fechaInicio, DateTime fechaFin, int estadoEnvio)
        {
            IEnumerable<ListadoEnvioInfoRelevanteViewModel> listado = new List<ListadoEnvioInfoRelevanteViewModel>();
            try
            {
                BuscarEnvioPorFechasViewModel envio = new BuscarEnvioPorFechasViewModel
                {
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Estado = estadoEnvio
                };
                string url = "https://localhost:7189/api/Envio/BuscarEnvioPorFechas";
                ResHttpViewModel datos = WebApi_Process(url, envio, "POST");

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoEnvioInfoRelevanteViewModel>>(datos.Datos);
                    if (listado.Count() == 0)
                    {
                        listado = new List<ListadoEnvioInfoRelevanteViewModel>();
                        ViewBag.MensajeError = "No hay Envios";
                    }
                } else
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
            IEnumerable<ListadoEnviosViewModel> listado = new List<ListadoEnviosViewModel>();
            try
            {
                string url = "https://localhost:7189/api/Envio/BuscarEnvioPorComentario/" + comentario;
                ResHttpViewModel datos = WebApi_Process(url);

                if (datos.Respuesta.IsSuccessStatusCode)
                {
                    listado = JsonConvert.DeserializeObject<List<ListadoEnviosViewModel>>(datos.Datos);
                    if (listado.Count() == 0)
                    {
                        listado = new List<ListadoEnviosViewModel>();
                        ViewBag.MensajeError = "No hay Envios";
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

    }
}