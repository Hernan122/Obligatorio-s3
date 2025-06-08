using Compartido.DTOs.UsuarioDTO;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CULoginUsuario : ILoginUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CULoginUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public InformacionUsuarioLogueadoViewModelDTO Ejecutar(LoginUsuarioDTO usuarioDTO)
        {
            Usuario usuario = RepoUsuarios.FindByEmailAndPassword(usuarioDTO.Email, usuarioDTO.Password);
            if (usuario == null)
            {
                throw new Exception("Usuario inexistente o credenciales incorrectas");
            }

            return new InformacionUsuarioLogueadoViewModelDTO()
            {
                Id = usuario.Id,
                Rol = usuario.Rol.ToString()
            };
        }
    }
}