using LogicaNegocio.ExcepcionesEntidades;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using Microsoft.AspNetCore.Mvc;


namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private IAltaUsuario CUAltaUsuario { get; set; }


    }
}
