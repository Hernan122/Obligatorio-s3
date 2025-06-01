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
        private IVerDetallesEnvio CUVerDetallesEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private IEditarEnvio CUEditarEnvio { get; set; }
        private IBuscarEnvio CUBuscarEnvio { get; set; }
        private ICambiarEstadoEnvio CUCambiarEstadoEnvio { get; set; }
        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IVerDetallesEnvio cuVerDetallesEnvio,
            IBajaEnvio cuBajaEnvio,
            IEditarEnvio cuEditarEnvio,
            IBuscarEnvio cuBuscarEnvio
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUVerDetallesEnvio = cuVerDetallesEnvio;
            CUBajaEnvio = cuBajaEnvio;
            CUEditarEnvio = cuEditarEnvio;
            CUBuscarEnvio = cuBuscarEnvio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var listadoEnviosViewModel = new List<ListadoEnvioViewModel>();
            try
            {
                var enviosDTO = CUListadoEnvio.Ejecutar();
                listadoEnviosViewModel = enviosDTO.Select(u => new ListadoEnvioViewModel()
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
                ViewBag.MensajeError = e.Message;
                ViewBag.MensajeError += ", " + e.InnerException;
                ViewBag.MensajeError += ", " + e.StackTrace;
                return View(listadoEnviosViewModel);
            }

            /* 
                HttpClient cliente = new HttpClient();
                Tast<HttpResponseMessage> tarea = cliente.GetAsync("https://localhost:5031/api/Envio");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;

                HttpContento contenido = respuesta.Content;
                Task<string> body = contenido.ReadAsStringAsync();
                body.Wait();
                string datos = body.Result;

                if (respuesta.IsSuccessStatusCode) {
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
                return View("CrearEnvio");
            }
        }

        public ActionResult CrearEnvioComun(AltaComunViewModel envio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AltaEnvioDTO envioDTO = new AltaComunDTO()
                    {
                        NumeroTracking = envio.NumeroTracking,
                        PesoPaquete = envio.PesoPaquete,
                        EmailCliente = envio.EmailCliente,
                        Fecha = DateTime.Today,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                        NombreAgencia = envio.NombreAgencia
                    };
                    AltaSeguimientoDTO seguimientoDTO = new AltaSeguimientoDTO()
                    {
                        Fecha = DateTime.Today,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                    };
                    CUAltaEnvio.Ejecutar(envioDTO, seguimientoDTO);
                    return RedirectToAction(nameof(Index), new { Mensaje = "Envio creado con exito" });
                }
                else
                {
                    throw new Exception("Valores no validos");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                ViewBag.MensajeError += e.InnerException;
                return View("~/Views/Envio/Comun/Crear.cshtml");
            }
        }

        public ActionResult CrearEnvioUrgente(AltaUrgenteViewModel envio)
        {
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
                    AltaSeguimientoDTO seguimientoDTO = new AltaSeguimientoDTO()
                    {
                        Fecha = DateTime.Today,
                        FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
                        //Comentario = envio.Comentario,
                    };
                    CUAltaEnvio.Ejecutar(envioDTO, seguimientoDTO);
                    return RedirectToAction("CrearEnvio", new { Mensaje = "Envio creado con exito" });
                }
                else
                {
                    throw new Exception("Valores no validos");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                return View("~/Views/Envio/Urgente/Crear.cshtml");
            }
        }

        [HttpGet]
        public ActionResult BajaEnvio(int id)
        {
            try
            {
                CUBajaEnvio.Ejecutar(id);
                return RedirectToAction(nameof(Index), new { Mensaje = "Eliminado con exito" });
            }
            catch (Exception e)
            {
                //ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
                //ViewBag.MensajeError += ", " + e.InnerException;
                return RedirectToAction(nameof(Index), new { MensajeError = e.Message });
            }
        }

        [HttpPost]
        public ActionResult CambiarComentarioEnvio(int id, string type)
        {
            AltaSeguimientoDTO seguimientoDTO = new AltaSeguimientoDTO()
            {
                Fecha = DateTime.Today,
                FuncionarioId = (int)HttpContext.Session.GetInt32("Id"),
            };
            CUCambiarEstadoEnvio.Ejecutar(id, type, seguimientoDTO);
            if (type == "EnCamino")
            {

            }
            return View();
        }
    }
}