using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using MVC.Models.Envio;
using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioComunDTO;
//using LogicaAplicacion.InterfacesCasosUso.IEnvioComunCU;
using Compartido.DTOs.EnvioUrgenteDTO;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private IListadoEnvio CUListadoEnvio { get; set; }
        private IAltaEnvio CUAltaEnvio { get; set; }
        private IVerDetallesEnvio CUVerDetalleEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private IEditarEnvio CUEditarEnvio { get; set; }

        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IVerDetallesEnvio cuVerDetalleEnvio,
            IBajaEnvio cuBajaEnvio,
            IEditarEnvio cuEditarEnvio
        )
        {
            CUListadoEnvio = cuListadoEnvio;
            CUAltaEnvio = cuAltaEnvio;
            CUVerDetalleEnvio = cuVerDetalleEnvio;
            CUBajaEnvio = cuBajaEnvio;
            CUEditarEnvio = cuEditarEnvio;
        }

        // GET: EnvioController
        public ActionResult Index()
        {
            // Funciona
            //var rol = HttpContext.Session.GetString("Rol");
            //if (rol != "Administrador")
            //{
            //    return Redirect("/Usuario/Login");
            //}

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

                return View(listadoEnviosViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                ViewBag.MensajeError += ", " + e.InnerException;
                ViewBag.MensajeError += ", " + e.StackTrace;
                return View(new List<ListadoEnvioViewModel>());
            }
        }

        // GET: EnvioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnvioController/Create
        public ActionResult CrearEnvio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearEnvio(int tipoEnvio)
        {
            try
            {
                if (tipoEnvio == 0)
                {
                    return Redirect("CrearComun");
                }
                else if (tipoEnvio == 1)
                {
                    return Redirect("CrearUrgente");
                }
                else
                {
                    throw new EnvioException("No existe ese tipo de envio");
                }
            }
            catch (EnvioException e)
            {
                ViewBag.MensajeError = e.Message;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEnvio(AltaEnvioViewModel? envio, int tipoEnvio)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        AltaEnvioComunDTO envioDTO = new AltaEnvioComunDTO()
            //        {
            //            //TipoEnvio = envio.TipoEnvio,
            //            EmailCliente = envio.EmailCliente,
            //            DireccionPostal = envio.DireccionPostal,
            //            PesoPaquete = envio.PesoPaquete
            //        };
            //        CUAltaEnvio.Ejecutar(envioDTO, 0); // Dentro de AltaEnvio se valida el tipo de envio
            //        ViewBag.Mensaje = "Usuario agregado";
            //    }
            //    ViewBag.Mensaje = "Envio creado con exito";
            //    return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    ViewBag.MensajeError = e.Message;
            //    //ViewBag.MensajeError += ", " + e.StackTrace;
            //}
            return View();
        }

        [HttpGet]
        public ActionResult FormCrearComun()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormCrearComun(AltaEnvioViewModel envio)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        AltaEnvioComunDTO envioDTO = new AltaEnvioComunDTO()
            //        {
            //            //TipoEnvio = envio.TipoEnvio,
            //            EmailCliente = envio.EmailCliente,
            //            DireccionPostal = envio.DireccionPostal,
            //            PesoPaquete = envio.PesoPaquete
            //        };
            //        CUAltaEnvio.Ejecutar(envioDTO, 0); // Dentro de AltaEnvio se valida el tipo de envio
            //        ViewBag.Mensaje = "Usuario agregado";
            //    }
            //    ViewBag.Mensaje = "Envio creado con exito";
            //    return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    ViewBag.MensajeError = e.Message;
            //    //ViewBag.MensajeError += ", " + e.StackTrace;
            //}
            return View();
        }

        [HttpGet]
        public ActionResult FormCrearUrgente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormCrearUrgente(AltaEnvioViewModel envio)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        AltaEnvioUrgenteDTO envioDTO = new AltaEnvioUrgenteDTO()
            //        {
            //            //TipoEnvio = envio.TipoEnvio,
            //            EmailCliente = envio.EmailCliente,
            //            DireccionPostal = envio.DireccionPostal,
            //            PesoPaquete = envio.PesoPaquete
            //        };

            //        CUAltaEnvio.Ejecutar(envioDTO, 1); // Dentro de AltaEnvio se valida el tipo de envio
            //        ViewBag.Mensaje = "Usuario agregado";
            //    }
            //    ViewBag.Mensaje = "Envio creado con exito";
            //    return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    ViewBag.MensajeError = e.Message;
            //    //ViewBag.MensajeError += ", " + e.StackTrace;
            //}
            return View();
        }

        // GET: EnvioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnvioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EnvioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnvioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}