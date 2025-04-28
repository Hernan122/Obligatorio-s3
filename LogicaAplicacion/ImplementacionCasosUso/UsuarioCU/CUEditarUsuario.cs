using Compartido.DTOs.UsuarioDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Usuario;
using Compartido.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUEditarUsuario : IEditarUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUEditarUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

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