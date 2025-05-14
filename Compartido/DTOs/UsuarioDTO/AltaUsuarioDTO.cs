using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.UsuarioDTO
{
    public class AltaUsuarioDTO
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}