using Compartido.DTOs.UsuarioDTO.CRUD;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class ListadoUsuario
    {
        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();

        public List<VerUsuarioDTO> Ejecutar()
        {
            List<VerUsuarioDTO> usuariosDTO = new List<VerUsuarioDTO>();
            List<Usuario> usuarios = RepoUsuarios.GetAll();
            usuariosDTO = UsuarioMapper.ListadoCarreraAListadoCarreraDTO(usuarios);
            return usuariosDTO;
        }
    }
}