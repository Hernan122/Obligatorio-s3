using LogicaAccesoDatos.Repositorios;
using Compartido.DTOs.UsuarioDTO.CRUD;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Usuario;
using Compartido.Mappers;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUEditarUsuario
    {
        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();

        //public void Ejecutar(EditarUsuarioDTO usuarioDTO)
        //{
        //    Usuario usuario = RepoUsuarios.FindById(usuarioDTO.Id);
        //    if (usuario == null)
        //    {
        //        throw new UsuarioException("Usuario no existente");
        //    }
        //    Usuario usuarioFromUsuarioDTO = new Usuario
        //    {
        //        Id = usuarioDTO.Id,
        //        Nombre = new NombreUsuario(usuarioDTO.NombreUsuario),
        //        Email = new EmailUsuario(usuarioDTO.Email),
        //        Password = new PasswordUsuario(usuarioDTO.Password),
        //        Rol = usuarioDTO.Rol
        //    };
        //    RepoUsuarios.Update(usuarioFromUsuarioDTO);
        //}

        public void Ejecutar(EditarUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new UsuarioException("Usuario no existente");
            }
            Usuario usuario = UsuarioMapper.UsuarioFromEditarUsuarioDTO(usuarioDTO);
            RepoUsuarios.Update(usuario);
        }
    }
}