using Compartido.DTOs.UsuarioDTO;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUListadoUsuario : IListadoUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUListadoUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public List<ListadoEnvioDTO> Ejecutar()
        {
            List<ListadoEnvioDTO> usuariosDTO = new List<ListadoEnvioDTO>();
            List<Usuario> usuarios = RepoUsuarios.FindAll().ToList();
            usuariosDTO = UsuarioMapper.ListadoUsuarioToListadoUsuarioDTO(usuarios);
            return usuariosDTO;
        }

    }
}