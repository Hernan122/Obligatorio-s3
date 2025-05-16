using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Compartido.DTOs.UsuarioDTO;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUAltaUsuario : IAltaUsuario
    {

        private IRepositorioUsuario RepoUsuarios { get; set; }

        // Inyección de dependencia
        public CUAltaUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public void Ejecutar(AltaUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario usuario = UsuarioMapper.UsuarioFromAltaUsuarioDTO(usuarioDTO);
            Usuario buscarUsuario = RepoUsuarios.FindByEmail(usuario);

            if (buscarUsuario == null)
            {
                RepoUsuarios.Add(usuario);
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese correo");
            }
        }
    }
}