using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario
    {
        private static List<Usuario> Usuarios = new List<Usuario>();

        public void Add(Usuario usuario)
        {
            if (!Usuarios.Contains(usuario))
            {
                Usuarios.Add(usuario);
            }
            else
            {
                throw new UsuarioException("Usuario ya existente");
            }
        }

        public List<Usuario> GetAll()
        {
            return Usuarios;
        }
    }
}