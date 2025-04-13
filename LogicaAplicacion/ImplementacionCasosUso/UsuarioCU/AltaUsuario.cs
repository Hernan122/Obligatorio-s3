using Compartido.DTOs.UsuarioDTO;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class AltaUsuario
    {

        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();

        public void Ejecutar(AltaUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO);
            RepoUsuarios.Add(usuario);
        }
    }
}