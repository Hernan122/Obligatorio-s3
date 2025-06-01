using Compartido.DTOs.UsuarioDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;

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
            Usuario rolUsuario = RepoUsuarios.FindById(usuarioDTO.Id);
            if (rolUsuario == null)
            {
                throw new UsuarioException("Usuario no encontrado");
            }
            Usuario usuario = UsuarioMapper.UsuarioFromEditarUsuarioDTO(usuarioDTO, rolUsuario.Rol);
            RepoUsuarios.Update(usuario);
        }

    }
}
