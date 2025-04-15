using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.UsuarioDTO.CRUD
{
    public class EditarUsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}