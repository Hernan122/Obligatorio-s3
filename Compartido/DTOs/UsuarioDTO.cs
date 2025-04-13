using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs
{
    public class AltaUsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public Rol Rol { get; set; }
    }
}