using Compartido.DTOs.UsuarioDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario UsuarioFromUsuarioDTO(AltaUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentException("Datos incorrectos");
            }
            return new Usuario(
                usuarioDTO.NombreUsuario,
                usuarioDTO.Email,
                usuarioDTO.Password,
                usuarioDTO.Rol
            );
        }

        public static List<ListadoUsuarioDTO> ListadoCarreraAListadoCarreraDTO(List<Usuario> usuarios)
        {
            List<ListadoUsuarioDTO> listadoUsuariosDTO = new List<ListadoUsuarioDTO>();
            listadoUsuariosDTO = usuarios.Select(user => new ListadoUsuarioDTO()
            {
                Id = user.Id,
                NombreUsuario = user.NombreUsuario,
            }).ToList();
            return listadoUsuariosDTO;
        }

    }
}