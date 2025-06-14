using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUCambiarPassword : ICambiarPassword
    {

        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUCambiarPassword(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public void Ejecutar(int id, string password)
        {
            Usuario usuario = RepoUsuarios.FindById(id);
            if (usuario == null)
            {
                throw new UsuarioException("No existe usuario");
            }

            usuario.Password = new PasswordUsuario(password);
            RepoUsuarios.Update(usuario);
        }
    }
}