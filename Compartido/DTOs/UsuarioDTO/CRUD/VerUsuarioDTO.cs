using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.UsuarioDTO.CRUD
{
    public class VerUsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public Usuario usuario { get; set; }
    }
}