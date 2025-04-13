using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class UsuarioViewModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; } 
    }
}