using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.DTOs.EnvioDTO;
using MVC.Models.Envio;
using MVC.Models.Envio.Comun;
using MVC.Models.Envio.Urgente;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private IListadoEnvio CUListadoEnvio { get; set; }
        private IAltaEnvio CUAltaEnvio { get; set; }
        private IVerDetallesEnvio CUVerDetallesEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private IEditarEnvio CUEditarEnvio { get; set; }

        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IVerDetallesEnvio cuVerDetallesEnvio,
            IBajaEnvio cuBajaEnvio,
            IEditarEnvio cuEditarEnvio
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUVerDetallesEnvio = cuVerDetallesEnvio;
            CUBajaEnvio = cuBajaEnvio;
            CUEditarEnvio = cuEditarEnvio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Funciona
            //var rol = HttpContext.Session.GetString("Rol");
            //if (rol == "Cliente")
            //{
            //    return Redirect("/Usuario/Login");
            //}

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

                return View(listadoEnviosViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                ViewBag.MensajeError += ", " + e.InnerException;
                ViewBag.MensajeError += ", " + e.StackTrace;
                return View(listadoEnviosViewModel);
            }
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            VerDetallesEnvioDTO envioDTO = CUVerDetallesEnvio.Ejecutar(id);
            VerDetallesEnvioViewModel envioViewModel = null;
            try
            {
                if (envioDTO is Comun)
                {
                    VerDetallesComunDTO urgenteDTO = (VerDetallesComunDTO)envioDTO;
                    envioViewModel = new VerDetallesComunViewModel()
                    {
                        Id = envioDTO.Id,
                        NumeroTracking = envioDTO.NumeroTracking,
                        PesoPaquete = envioDTO.PesoPaquete,
                        Estado = envioDTO.Estado,
                        ClienteId = envioDTO.ClienteId,
                        FuncionarioId = envioDTO.FuncionarioId,
                        SeguimientoId = envioDTO.SeguimientoId,
                    };
                }
                else if (envioDTO is Urgente)
                {
                    VerDetallesUrgenteDTO urgenteDTO = (VerDetallesUrgenteDTO)envioDTO;
                    envioViewModel = new VerDetallesUrgenteViewModel()
                    {
                        Id = envioDTO.Id,
                        NumeroTracking = envioDTO.NumeroTracking,
                        PesoPaquete = envioDTO.PesoPaquete,
                        Estado = envioDTO.Estado,
                        ClienteId = envioDTO.ClienteId,
                        FuncionarioId = envioDTO.FuncionarioId,
                        SeguimientoId = envioDTO.SeguimientoId,
                        DireccionPostal = urgenteDTO.DireccionPostal,
                        EntregaEficiente = urgenteDTO.EntregaEficiente
                    };
                }
                else
                {
                    throw new Exception("Objeto nulo");
                }
                return View(envioViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return View();
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
            string url = $"~/Views/Envio/{param}/Crear.cshtml";
            try
            {
                if (type == "Comun" || type == "Urgente")
                {
                    param = type;
                }
                else
                {
                    throw new EnvioException($"No existe ese tipo de envio: {type}");
                }
                return View(url);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                return View("CrearEnvio");
            }
        }

        [HttpPost]
        public ActionResult FormCrearEnvio(string type, int tipo2)
        {
            try
            {
                if (type == "Comun")
                {
                    CrearEnvioComun(new AltaComunViewModel());
                    return RedirectToAction("CrearEnvio", new { Mensaje = "Envio creado con exito" });
                }
                else if (type == "Urgente")
                {
                    CrearEnvioUrgente(new AltaUrgenteViewModel());
                    return RedirectToAction("CrearEnvio", new { Mensaje = "Envio creado con exito" });
                }
                else
                {
                    throw new Exception("No existe ese tipo de envio");
                }
                
            }
            catch (Exception e)
            {
                return RedirectToAction("FormCrearEnvio", new { MensajeError = e.Message });
            }
        }

        public void CrearEnvioComun(AltaComunViewModel envio)
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
                    CUAltaEnvio.Ejecutar(envioDTO);
                }
                else
                {
                    throw new Exception("Valores no validos");
                }
        }

        public void CrearEnvioUrgente(AltaUrgenteViewModel envio)
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
                CUAltaEnvio.Ejecutar(envioDTO);
            } 
            else
            {
                throw new Exception("Valores no validos");
            }
        }

        [HttpGet]
        public ActionResult EditarEnvio(int id)
        {
            VerDetallesEnvioDTO envioDTO = CUVerDetallesEnvio.Ejecutar(id);
            VerDetallesEnvioViewModel envioViewModel = null;
            try
            {
                if (envioDTO is Comun)
                {
                    VerDetallesComunDTO comunDTO = (VerDetallesComunDTO)envioDTO;
                    envioViewModel = new VerDetallesComunViewModel()
                    {
                        Id = envioDTO.Id,
                        NumeroTracking = envioDTO.NumeroTracking,
                        PesoPaquete = envioDTO.PesoPaquete,
                        Estado = envioDTO.Estado,
                        ClienteId = envioDTO.ClienteId,
                        FuncionarioId = envioDTO.FuncionarioId,
                        SeguimientoId = envioDTO.SeguimientoId,
                    };
                }
                else
                {
                    VerDetallesUrgenteDTO urgenteDTO = (VerDetallesUrgenteDTO)envioDTO;
                    envioViewModel = new VerDetallesUrgenteViewModel()
                    {
                        Id = envioDTO.Id,
                        NumeroTracking = envioDTO.NumeroTracking,
                        PesoPaquete = envioDTO.PesoPaquete,
                        Estado = envioDTO.Estado,
                        ClienteId = envioDTO.ClienteId,
                        FuncionarioId = envioDTO.FuncionarioId,
                        SeguimientoId = envioDTO.SeguimientoId,
                        DireccionPostal = urgenteDTO.DireccionPostal,
                        EntregaEficiente = urgenteDTO.EntregaEficiente
                    };
                }
                return View(envioViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + " | " + e.StackTrace;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEnvio(string type)
        {
            try
            {
                if (type == "Comun")
                {
                    EditarEnvioComun(new EditarComunViewModel());
                }
                else if (type == "Urgente")
                {
                    EditarEnvioUrgente(new EditarUrgenteViewModel());
                }
                else
                {
                    throw new Exception("No existe ese tipo de envio");
                }
                return RedirectToAction("FormCrearEnvio", new { Mensaje = "Envio editado con exito" });
            }
            catch (Exception e)
            {
                return RedirectToAction("FormCrearEnvio", new { MensajeError = e.Message });
            }
        }

        [HttpPost]
        public void EditarEnvioComun(EditarComunViewModel envio)
        {
            if (ModelState.IsValid)
            {
                EditarComunDTO envioDTO = new EditarComunDTO()
                {
                    Id = envio.Id,
                    NumeroTracking = envio.NumeroTracking,
                    PesoPaquete = envio.PesoPaquete,
                };
                CUEditarEnvio.Ejecutar(envioDTO);
            }
        }

        [HttpPost]
        public void EditarEnvioUrgente(EditarUrgenteViewModel envio)
        {
            if (ModelState.IsValid)
            {
                EditarComunDTO envioDTO = new EditarComunDTO()
                {
                    Id = envio.Id,
                    NumeroTracking = envio.NumeroTracking,
                    PesoPaquete = envio.PesoPaquete,
                };
                CUEditarEnvio.Ejecutar(envioDTO);
            }
        }


        [HttpPost]
        public ActionResult BajaEnvio(int id)
        {
            try
            {
                CUBajaEnvio.Ejecutar(id);
                ViewBag.Mensaje = "Envio Eliminado con Éxito";
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}