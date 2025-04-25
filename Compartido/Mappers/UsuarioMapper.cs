using LogicaNegocio.ExcepcionesEntidades;
using Compartido.DTOs.UsuarioDTO.CRUD;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject.Usuario;
using Compartido.DTOs.UsuarioDTO;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario UsuarioFromAltaUsuarioDTO(AltaUsuarioDTO usuarioDTO)
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

        public static Usuario UsuarioFromBajaUsuarioDTO(BajaUsuarioDTO usuarioDTO)
        {
            return null;
        }

        public static Usuario UsuarioFromEditarUsuarioDTO(EditarUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new UsuarioException("Usuario null");
            }
            return new Usuario
            (
                usuarioDTO.Id,
                usuarioDTO.NombreUsuario,
                usuarioDTO.Email,
                usuarioDTO.Password,
                usuarioDTO.Rol
            );
        }

        public static Usuario UsuarioFromLoginUsuarioDTO(LoginUsuarioDTO usuarioDTO)
        {
            return new Usuario()
            { 
                Email = new EmailUsuario(usuarioDTO.Email),
                Password = new PasswordUsuario(usuarioDTO.Password)
            };
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
    }
}