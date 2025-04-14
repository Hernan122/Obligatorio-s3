using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.UsuarioDTO.CRUD
{
    public class BajaUsuarioDTO
    {
        public int Id { get; set; }
        public Usuario usuario { get; set; }
    }
}