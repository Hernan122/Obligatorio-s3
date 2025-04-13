using Compartido.DTOs.UsuarioDTO;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class ListadoUsuario
    {
        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();

        public List<ListadoUsuarioDTO> Ejecutar()
        {
            List<ListadoUsuarioDTO> usuariosDTO = new List<ListadoUsuarioDTO>();
            List<Usuario> usuarios = RepoUsuarios.GetAll();
            usuariosDTO = UsuarioMapper.ListadoCarreraAListadoCarreraDTO(usuarios);
            return usuariosDTO;
        }
    }
}