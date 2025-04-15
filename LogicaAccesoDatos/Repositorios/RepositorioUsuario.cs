using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> Usuarios = new List<Usuario>();

        static RepositorioUsuario()
        {
            Usuarios.Add(new Usuario("Bruno1234", "bruno@example.com", "1234", Rol.Administrador));
            Usuarios.Add(new Usuario("Ana12345", "ana@example.com", "5678", Rol.Funcionario));
            Usuarios.Add(new Usuario("Carlos1234", "carlos@example.com", "abcd", Rol.Funcionario));
            Usuarios.Add(new Usuario("Cliente0", "cliente@example.com", "cliente0", Rol.Cliente));
        }

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

        public void Delete(int id)
        {
            Usuario usuario = FindById(id);
            if (usuario == null)
            {
                throw new UsuarioException("No se ha encontrado el usuario");
            }
            Usuarios.Remove(usuario);
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Usuarios;
        }

        public Usuario FindById(int id)
        {
            foreach (Usuario usuario in Usuarios)
            {
                if (usuario.Id == id)
                {
                    return usuario;
                }
            }
            return null;
        }

        public void Update(Usuario usuario)
        {
            foreach (Usuario item in Usuarios)
            {
                if (item.Id == usuario.Id)
                {
                    item.Id = usuario.Id;
                    item.Nombre = usuario.Nombre;
                    item.Email = usuario.Email;
                    item.Password = usuario.Password;
                    item.Rol = usuario.Rol;
                }
            }
        }

        public Usuario FindByEmailAndPassword(Usuario usuario)
        {
            foreach (Usuario item in Usuarios)
            {
                if (item.Email.Valor == usuario.Email.Valor && item.Password.Valor == usuario.Password.Valor)
                {
                    return usuario;
                }
            }
            return null;
        }

    }
}