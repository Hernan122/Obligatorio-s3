using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.DTOs.EnvioDTO;
using MVC.Models.Envio;
using MVC.Models.Envio.Comun;
using MVC.Models.Envio.Urgente;
using Compartido.DTOs.SeguimientoDTO;
using MVC.Filters;

namespace MVC.Controllers
{
    [Login]
    public class EnvioController : Controller
    {
        private IListadoEnvio CUListadoEnvio { get; set; }
        private IAltaEnvio CUAltaEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private ICambiarEstadoEnvio CUCambiarEstadoEnvio { get; set; }
        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IBajaEnvio cuBajaEnvio
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUBajaEnvio = cuBajaEnvio;
        }

        [HttpGet]
        public ActionResult Index(string mensaje, string mensajeError)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.MensajeError = mensajeError;
            try
            {
                var enviosDTO = CUListadoEnvio.Ejecutar();
                var listadoEnviosViewModel = enviosDTO.Select(u => new ListadoEnvioViewModel()
                {
                    Id = u.Id,
                    NumeroTracking = u.NumeroTracking,
                    Estado = u.Estado,
                    FuncionarioId = u.FuncionarioId
                }).ToList();

                if (listadoEnviosViewModel.Count() == 0)
                {
                    ViewBag.MensajeError = "No hay envios";
                }

                return View(listadoEnviosViewModel);
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                //mensaje += e.InnerException;
                //mensaje += e.StackTrace;
                ViewBag.MensajeError = mensaje;
                return View(new List<ListadoEnvioViewModel>());
            }

            /* 
                HttpClient cliente = new HttpClient();
                Tast<HttpResponseMessage> tarea = cliente.GetAsync("https://localhost:5031/api/Envio");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result; // Codigo de estado de la respuesta (200)

                HttpContento contenido = respuesta.Content;
                Task<string> body = contenido.ReadAsStringAsync();
                body.Wait();
                string datos = body.Result;

                if (respuesta.IsSuccessStatusCode) { // si respuesta es 200
                    listadoEnviosViewModel = JsonConvert.DeserealizeObject<List<DatoEnvioViewModel>>(datos);
                } else {
                    ViewBag.Mensaje = datos;
                }
             */
        }

        [HttpGet]
        public ActionResult CrearEnvio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FormCrearEnvio(string type)
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
                    throw new EnvioException($"No existe ese tipo de envio: {type}");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                return View(nameof(CrearEnvio));
            }
        }

        [HttpPost]
        public ActionResult CrearEnvioComun(AltaComunViewModel envio)
        {
            string mensaje = "";
            try
            {
                if (ModelState.IsValid)
                {
                    AltaEnvioDTO envioDTO = new AltaComunDTO
                    {
                        NumeroTracking = envio.NumeroTracking,
                        PesoPaquete = envio.PesoPaquete,
                        EmailCliente = envio.EmailCliente,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                        Fecha = DateTime.Today,
                        NombreAgencia = envio.NombreAgencia
                    };
                    AltaSeguimientoDTO seguimientoDTO = new()
                    {
                        Fecha = DateTime.Today,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                    };
                    CUAltaEnvio.Ejecutar(envioDTO, seguimientoDTO);
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
        public ActionResult CrearEnvioUrgente(AltaUrgenteViewModel envio)
        {
            string mensaje;
            try
            {
                if (ModelState.IsValid)
                {
                    AltaEnvioDTO envioDTO = new AltaUrgenteDTO()
                    {
                        NumeroTracking = envio.NumeroTracking,
                        PesoPaquete = envio.PesoPaquete,
                        EmailCliente = envio.EmailCliente,
                        Fecha = DateTime.Today,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                        DireccionPostal = envio.DireccionPostal,
                        EntregaEficiente = envio.EntregaEficiente
                    };
                    AltaSeguimientoDTO seguimientoDTO = new ()
                    {
                        Fecha = DateTime.Today,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                    };
                    CUAltaEnvio.Ejecutar(envioDTO, seguimientoDTO);
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

        [HttpGet]
        public ActionResult BajaEnvio(int id)
        {
            string mensaje;
            try
            {
                CUBajaEnvio.Ejecutar(id);
                return RedirectToAction(nameof(Index), new { Mensaje = "Eliminado con exito" });
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                //mensaje += e.StackTrace;
                //mensaje += e.InnerException;
            }
            return RedirectToAction(nameof(Index), new { MensajeError = mensaje });
        }
    }
}