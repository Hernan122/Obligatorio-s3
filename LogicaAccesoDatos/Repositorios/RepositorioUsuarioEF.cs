using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject.Usuario;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private DemoContext Contexto { get; set; }

        public RepositorioUsuarioEF(DemoContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario usuario)
        {
            if (!Contexto.Usuarios.Contains(usuario))
            {
                Contexto.Usuarios.Add(usuario);
                Contexto.SaveChanges();
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
            Contexto.Usuarios.Remove(usuario);
            Contexto.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios;
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public void Update(Usuario usuario)
        {
            Usuario newUsuario = FindById(usuario.Id);
            if (newUsuario == null)
            {
                throw new UsuarioException("No se encontro al usuario a actualizar");
            }
            Contexto.Usuarios.Update(usuario);
            Contexto.SaveChanges();
        }

        public Usuario FindByEmailAndPassword(Usuario usuario)
        {
            return Contexto.Usuarios
                    .Where(c => c.Email == usuario.Email && c.Password == usuario.Password)
                    .FirstOrDefault();
        }

        public Usuario FindByEmail(Usuario usuario)
        {
            return Contexto.Usuarios
                    .Where(c => c.Email == usuario.Email)
                    .FirstOrDefault();
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios
                    .Where(c => c.Email == email)
                    .FirstOrDefault();
        }

    }
}