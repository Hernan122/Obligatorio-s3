using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

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
        }

        public IEnumerable<Usuario> FindAll()
        {
            //return Usuarios;
            return null;
        }

        public Usuario FindById(int id)
        {
            //foreach (Usuario usuario in Usuarios)
            //{
            //    if (usuario.Id == id)
            //    {
            //        return usuario;
            //    }
            //}
            return null;
        }

        public void Update(Usuario usuario)
        {
            //foreach (Usuario item in Usuarios)
            //{
            //    if (item.Id == usuario.Id)
            //    {
            //        item.Id = usuario.Id;
            //        item.Nombre = usuario.Nombre;
            //        item.Email = usuario.Email;
            //        item.Password = usuario.Password;
            //        item.Rol = usuario.Rol;
            //    }
            //}
        }

        public Usuario FindByEmailAndPassword(Usuario usuario)
        {
            //foreach (Usuario item in Usuarios)
            //{
            //    if (item.Email.Valor == usuario.Email.Valor && item.Password.Valor == usuario.Password.Valor)
            //    {
            //        return item;
            //    }
            //}
            return null;
        }

    }
}