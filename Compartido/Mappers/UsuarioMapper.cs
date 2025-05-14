using LogicaNegocio.ExcepcionesEntidades;
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
                throw new ArgumentException("Usuario Null");
            }
            return new Usuario()
            { 
                Nombre = new NombreUsuario(usuarioDTO.NombreUsuario),
                Email = new EmailUsuario(usuarioDTO.Email),
                Password = new PasswordUsuario(usuarioDTO.Password),
                Rol = usuarioDTO.Rol
            };
        }

        public static Usuario UsuarioFromBajaUsuarioDTO(BajaUsuarioDTO usuarioDTO)
        {
            return new Usuario()
            {
                Id = usuarioDTO.Id
            };
        }

        public static Usuario UsuarioFromEditarUsuarioDTO(EditarUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new UsuarioException("Usuario null");
            }
            return new Usuario()
            { 
                Id = usuarioDTO.Id,
                Nombre = new NombreUsuario(usuarioDTO.NombreUsuario),
                Email = new EmailUsuario(usuarioDTO.Email),
                Password = new PasswordUsuario(usuarioDTO.Password),
                Rol = usuarioDTO.Rol
            };
        }

        public static Usuario UsuarioFromLoginUsuarioDTO(LoginUsuarioDTO usuarioDTO)
        {
            return new Usuario()
            {
                Email = new EmailUsuario(usuarioDTO.Email),
                Password = new PasswordUsuario(usuarioDTO.Password),
            };
        }

        public static List<ListadoEnvioDTO> ListadoUsuarioToListadoUsuarioDTO(List<Usuario> usuarios)
        {
            List<ListadoEnvioDTO> listadoUsuariosDTO = new List<ListadoEnvioDTO>();
            listadoUsuariosDTO = usuarios.Select(user => new ListadoEnvioDTO()
            {
                Id = user.Id,
                NombreUsuario = user.Nombre.Valor,
            }).ToList();
            return listadoUsuariosDTO;
        }
    }
}