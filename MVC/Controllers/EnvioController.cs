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
using Compartido.DTOs.SeguimientoDTO;
using Compartido.DTOs.UsuarioDTO;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
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
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "Cliente")
            {
                return Redirect("/Usuario/Login");
            }

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
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            VerDetallesEnvioDTO envioDTO = CUVerDetallesEnvio.Ejecutar(id);
            VerDetallesEnvioViewModel envioViewModel = null;
            string param = "";
            try
            {
                if (envioDTO is VerDetallesComunDTO)
                {
                    param = "Comun";
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
                        NombreAgencia = comunDTO.NombreAgencia
                    };
                }
                else if (envioDTO is VerDetallesUrgenteDTO)
                {
                    param = "Urgente";
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
                //string url = $"~/Views/Envio/{param}/Crear.cshtml";
                //return View($"~/Views/Envio/Comun/Detalles.cshtml");
                return View($"~/Views/Envio/{param}/Detalles.cshtml", envioViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message; ;
                ViewBag.MensajeError += e.StackTrace;
                return View();
            }
        }

        [HttpGet]
        public ActionResult CrearEnvio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FormCrearEnvio(string type)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "Cliente")
            {
                return Redirect("/Usuario/Login");
            }

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

        public ActionResult CrearEnvioComun(AltaComunViewModel envio)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "Cliente")
            {
                return Redirect("/Usuario/Login");
            }

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
                        //Comentario = envio.Comentario,
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
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "Cliente")
            {
                return Redirect("/Usuario/Login");
            }

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
        public ActionResult EditarEnvio(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "Cliente")
            {
                return Redirect("/Usuario/Login");
            }

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
        public ActionResult FormEditarEnvio(int id)
        {
            VerDetallesEnvioDTO envio = CUBuscarEnvio.Ejecutar(id);

            EditarEnvioViewModel envioVM = null;
            string param = "";

            if (envio is VerDetallesComunDTO)
            {
                envioVM = new EditarComunViewModel()
                {
                    NumeroTracking = envio.NumeroTracking,
                };
                param = "comun";
            }
            else
            {
                envioVM = new EditarUrgenteViewModel()
                {

                };
                param = "urgente";
            }
            return View($"~/Views/Envio/{param}/Editar.cshtml", envioVM);
        }

        [HttpPost]
        public ActionResult EditarEnvioComun(EditarComunViewModel envio)
        {
            try
            {
                EditarComunDTO envioDTO = new EditarComunDTO()
                {
                    Id = envio.Id,
                    NumeroTracking = envio.NumeroTracking,
                    PesoPaquete = envio.PesoPaquete,
                };
                CUEditarEnvio.Ejecutar(envioDTO);
                return RedirectToAction(nameof(Index), new { MensajeError = "Envio Comun Editado con Éxito"});
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { MensajeError = e.InnerException});
            }
        }

        [HttpPost]
        public ActionResult EditarEnvioUrgente(EditarUrgenteViewModel envio)
        {
            try
            {
                EditarComunDTO envioDTO = new EditarComunDTO()
                {
                    Id = envio.Id,
                    NumeroTracking = envio.NumeroTracking,
                    PesoPaquete = envio.PesoPaquete,
                };
                CUEditarEnvio.Ejecutar(envioDTO);
                return RedirectToAction(nameof(Index), new { MensajeError = "Envio Urgente Editado con Éxito"});
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { MensajeError = e.InnerException });
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