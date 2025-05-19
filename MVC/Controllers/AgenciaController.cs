using Compartido.DTOs.AgenciaDTO;
using Compartido.DTOs.UsuarioDTO;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Agencia;
using MVC.Models.Envio;

namespace MVC.Controllers
{
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
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "Cliente")
            {
                return Redirect("/Usuario/Login");
            }

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

        // GET: AgenciaController/Details/5
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

        // GET: AgenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgenciaController/Edit/5
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

        // GET: AgenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgenciaController/Delete/5
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
