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

        public List<VerUsuarioDTO> Ejecutar()
        {
            List<VerUsuarioDTO> usuariosDTO = new List<VerUsuarioDTO>();
            List<Usuario> usuarios = RepoUsuarios.FindAll().ToList();
            usuariosDTO = UsuarioMapper.ListadoCarreraAListadoCarreraDTO(usuarios);
            return usuariosDTO;
        }

    }
}