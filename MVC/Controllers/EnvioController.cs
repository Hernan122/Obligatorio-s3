using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnvioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel envio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AltaEnvioDTO usuarioDTO = new AltaEnvioDTO()
                    {

                    };

                    CUAltaUsuario.Ejecutar(usuarioDTO);
                    ViewBag.Mensaje = "Usuario agregado";
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message + ", " + e.StackTrace;
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
