using Compartido.DTOs.AgenciaDTO;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models.Agencia;

namespace MVC.Controllers
{
    [Login]
    public class AgenciaController : Controller
    {

        private IListadoAgencia CUListadoAgencia { get; set; }
        private IAltaAgencia CUAltaAgencia { get; set; }

        public AgenciaController
        (
            IListadoAgencia cuListadoAgencia,
            IAltaAgencia cuAltaAgencia
        )
        {
            CUListadoAgencia = cuListadoAgencia;
            CUAltaAgencia = cuAltaAgencia;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var listadoAgenciaViewModel = new List<ListadoAgenciaViewModel>();
            try
            {
                var agenciaDTO = CUListadoAgencia.Ejecutar();
                listadoAgenciaViewModel = agenciaDTO.Select(c => new ListadoAgenciaViewModel()
                {
                    Nombre = c.Nombre,
                    UsuarioId = c.UsuarioId
                }).ToList();

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
            try
            {
                if (ModelState.IsValid)
                {
                    AltaAgenciaDTO agenciaDTO = new AltaAgenciaDTO()
                    {
                        UbPos = agencia.UbPos,
                        CoordenadasLatitud = agencia.CoordenadasLatitud,
                        CoordenadasLongitud = agencia.CoordenadasLongitud,
                        Nombre = agencia.Nombre,
                        UsuarioId = (int)HttpContext.Session.GetInt32("Id"),
                    };

                    CUAltaAgencia.Ejecutar(agenciaDTO);
                    return RedirectToAction(nameof(AltaAgencia), new { Mensaje = "Agencia creada" });
                }
                else
                {
                    throw new ArgumentNullException("Debe rellenar todos los valores");
                }
            }
            catch (Exception e)
            {
                ViewBag.MensajeError = e.Message;
                //ViewBag.MensajeError += ", " + e.StackTrace;
                ViewBag.MensajeError += ", " + e.InnerException;
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
