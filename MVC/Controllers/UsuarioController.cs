using LogicaNegocio.ExcepcionesEntidades;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;


namespace MVC.Controllers
{


    public class UsuarioController : Controller
    {
        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        private IAltaUsuario CUAltaUsuario { get; set; }


    }
}
