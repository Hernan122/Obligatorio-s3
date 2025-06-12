using Compartido.DTOs.UsuarioDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using Compartido.Mappers;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUVerDetalleUsuario : IVerDetalleUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUVerDetalleUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public VerDetallesUsuarioDTO Ejecutar(int id)
        {
            Usuario usuario = RepoUsuarios.FindById(id);
            if (usuario == null)
            {
                throw new UsuarioException("Usuario no existente");
            }

            VerDetallesUsuarioDTO usuarioDTO = UsuarioMapper.VerDetallesUsuarioDTOFromUsuario(usuario);
            return usuarioDTO;
        }
    }
}