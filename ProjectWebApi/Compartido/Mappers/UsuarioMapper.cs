using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using Compartido.DTOs.UsuarioDTO;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario UsuarioFromAltaUsuarioDTO(AltaUsuarioDTO usuarioDTO)
        {
            return new Usuario
            (
                usuarioDTO.NombreUsuario,
                usuarioDTO.Email,
                usuarioDTO.Password,
                usuarioDTO.Rol
            );
        }

        public static Usuario UsuarioFromEditarUsuarioDTO(EditarUsuarioDTO usuarioDTO, Rol rol)
        {
            return new Usuario
            (
                usuarioDTO.NombreUsuario,
                usuarioDTO.Email,
                usuarioDTO.Password,
                rol.ToString()
            );
        }

        public static List<ListadoUsuarioDTO> ListadoUsuarioToListadoUsuarioDTO(List<Usuario> usuarios)
        {
            List<ListadoUsuarioDTO> listadoUsuariosDTO = new List<ListadoUsuarioDTO>();
            listadoUsuariosDTO = usuarios.Select(user => new ListadoUsuarioDTO()
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Password = user.Password.Valor
            }).ToList();
            return listadoUsuariosDTO;
        }

        public static VerDetallesUsuarioDTO VerDetallesUsuarioDTOFromUsuario(Usuario usuario)
        {
            return new VerDetallesUsuarioDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password.Valor,
                Rol = usuario.Rol.ToString()
            };
        }
    }
}