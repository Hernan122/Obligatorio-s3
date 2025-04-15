using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using Compartido.DTOs.UsuarioDTO.CRUD;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUAltaUsuario
    {

        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();

        public void Ejecutar(AltaUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario usuario = UsuarioMapper.UsuarioFromAltaUsuarioDTO(usuarioDTO);
            RepoUsuarios.Add(usuario);
        }
    }
}