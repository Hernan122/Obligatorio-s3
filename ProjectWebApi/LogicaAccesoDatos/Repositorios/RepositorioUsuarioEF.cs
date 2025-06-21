using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Compartido.ExcepcionesConflictos;
using Microsoft.EntityFrameworkCore;

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
            Usuario usuarioTemp = FindByEmail(usuario.Email);
            if (usuarioTemp == null)
            {
                Contexto.Usuarios.Add(usuario);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ConflictException("Correo ya existente");
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
            return Contexto.Usuarios
                .Where(u => u.Auditorias.All(a => a.AccionRealizada != Accion.Eliminado) && u.Rol != Rol.Administrador)
                .ToList();
        }

        public Usuario? FindById(int id)
        {
            return Contexto.Usuarios
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public void Update(Usuario usuario)
        {
            Usuario findUserByRepeatedEmail = FindByRepeatedEmail(usuario.Email, usuario.Id);
            if (findUserByRepeatedEmail == null)
            {
                Usuario usuarioEditado = FindById(usuario.Id);
                usuarioEditado.Nombre = usuario.Nombre;
                usuarioEditado.Email = usuario.Email;
                usuarioEditado.Password = usuario.Password;
                usuarioEditado.Auditorias = usuario.Auditorias;

                Contexto.Usuarios.Update(usuarioEditado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ConflictException("Ya existe otro usuario con ese correo");
            }
        }

        public Usuario? FindByEmailAndPassword(string email, string password)
        {
            return Contexto.Usuarios
                    .Where(c => c.Email == email && c.Password.Valor == password)
                    .SingleOrDefault();
        }

        public Usuario? FindByEmail(string email)
        {
            return Contexto.Usuarios
                    .Where(c => c.Email == email)
                    .SingleOrDefault();
        }

        public Usuario? FindByRepeatedEmail(string email, int id)
        {
            return Contexto.Usuarios
                    .Where(c => c.Email == email && c.Id != id)
                    .SingleOrDefault();
        }
    }
}