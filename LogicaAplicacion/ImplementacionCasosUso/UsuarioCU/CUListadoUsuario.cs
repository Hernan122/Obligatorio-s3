using Compartido.DTOs.UsuarioDTO;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUListadoUsuario : IListadoUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUListadoUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public List<ListadoUsuarioDTO> Ejecutar()
        {
            List<ListadoUsuarioDTO> usuariosDTO = new List<ListadoUsuarioDTO>();
            List<Usuario> usuarios = RepoUsuarios.FindAll().ToList();
            usuariosDTO = UsuarioMapper.ListadoUsuarioToListadoUsuarioDTO(usuarios);
            return usuariosDTO;
        }

    }
}