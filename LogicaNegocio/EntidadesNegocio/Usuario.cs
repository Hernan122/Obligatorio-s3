using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IEquatable<Usuario>
    {
        public int Id { get; set; }
        public Rol Rol { get; set; }
        public NombreUsuario Nombre { get; set; }
        public EmailUsuario Email { get; set; }
        public PasswordUsuario Password { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string email, string password, Rol rol)
        {
            Nombre = new NombreUsuario(nombre);
            Email = new EmailUsuario(email);
            Password = new PasswordUsuario(password);
            Rol = rol;
            Validar();
        }

        private void Validar()
        {
            if (Rol == null)
            {
                throw new UsuarioException("El rol no puede estar vacío.");
            }
        }
        
        public bool Equals(Usuario? other)
        {
            return Nombre == other.Nombre;
        }
    }
}