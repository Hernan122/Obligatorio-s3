using Compartido.DTOs.UsuarioDTO.CRUD;
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

        public static List<VerUsuarioDTO> ListadoCarreraAListadoCarreraDTO(List<Usuario> usuarios)
        {
            List<VerUsuarioDTO> listadoUsuariosDTO = new List<VerUsuarioDTO>();
            listadoUsuariosDTO = usuarios.Select(user => new VerUsuarioDTO()
            {
                Id = user.Id,
                NombreUsuario = user.Nombre.Valor,
            }).ToList();
            return listadoUsuariosDTO;
        }

        public static VerDetallesUsuarioDTO UsuarioAUsuarioDTO(int i)
        {
            VerDetallesUsuarioDTO usuario = null;
            return usuario;
        }


    }
}