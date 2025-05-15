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
using LogicaAplicacion.InterfacesCasosUso.IEnvioComunCU;
using Compartido.DTOs.EnvioUrgenteDTO;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private IListadoEnvio CUListadoEnvio { get; set; }
        private IAltaEnvio CUAltaEnvio { get; set; }
        private IVerDetalleEnvio CUVerDetalleEnvio { get; set; }
        private IBajaEnvio CUBajaEnvio { get; set; }
        private IEditarEnvio CUEditarEnvio { get; set; }

        public EnvioController(
            IListadoEnvio cuListadoEnvio,
            IAltaEnvio cuAltaEnvio,
            IVerDetalleEnvio cuVerDetalleEnvio,
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
            return View();
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
                    return Redirect("CrearEnvioComun");
                }
                else if (tipoEnvio == 1)
                {
                    return Redirect("CrearEnvioUrgente");
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
        public ActionResult CrearEnvioComun(AltaEnvioViewModel envio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AltaEnvioComunDTO envioDTO = new AltaEnvioComunDTO()
                    {
                        //TipoEnvio = envio.TipoEnvio,
                        EmailCliente = envio.EmailCliente,
                        DireccionPostal = envio.DireccionPostal,
                        PesoPaquete = envio.PesoPaquete
                    };
                    CUAltaEnvio.Ejecutar(envioDTO, 0); // Dentro de AltaEnvio se valida el tipo de envio
                    ViewBag.Mensaje = "Usuario agregado";
                }
                ViewBag.Mensaje = "Envio creado con exito";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CrearEnvioUrgente(AltaEnvioViewModel envio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AltaEnvioUrgenteDTO envioDTO = new AltaEnvioUrgenteDTO()
                    {
                        //TipoEnvio = envio.TipoEnvio,
                        EmailCliente = envio.EmailCliente,
                        DireccionPostal = envio.DireccionPostal,
                        PesoPaquete = envio.PesoPaquete
                    };

                    CUAltaEnvio.Ejecutar(envioDTO, 1); // Dentro de AltaEnvio se valida el tipo de envio
                    ViewBag.Mensaje = "Usuario agregado";
                }
                ViewBag.Mensaje = "Envio creado con exito";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
            }
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