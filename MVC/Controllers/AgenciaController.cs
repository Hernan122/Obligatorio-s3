using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models.Agencia;

namespace MVC.Controllers
{
    [Login]
    public class AgenciaController : ControllerB
    {
        [HttpGet]
        public ActionResult Index()
        {
            var listadoAgenciaViewModel = new List<ListadoAgenciaViewModel>();
            try
            {
                return View(listadoAgenciaViewModel);
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                ViewBag.MensajeError += ", " + e.InnerException;
                ViewBag.MensajeError += ", " + e.StackTrace;
                return View(listadoAgenciaViewModel);
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult AltaAgencia(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult AltaAgencia(AltaAgenciaViewModel agencia)
        {
            string mensaje;
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Mensaje = "Agencia creada con exito";
                    return RedirectToAction(nameof(AltaAgencia), new { Mensaje = "Agencia creada" });
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException e)
            {
                mensaje = "Debe rellenar todos los valores";
                ViewBag.MensajeError = mensaje;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                //mensaje += e.StackTrace;
                //mensaje += e.InnerException;
                ViewBag.MensajeError = mensaje;
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
