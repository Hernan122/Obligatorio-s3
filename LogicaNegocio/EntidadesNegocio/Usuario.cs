using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Usuario;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario : IEquatable<Usuario>
    {
        public int Id { get; set; }
        private static int s_ultId;
        public NombreUsuario Nombre { get; set; }
        public EmailUsuario Email { get; set; }
        public PasswordUsuario Password { get; set; }
        public Rol Rol { get; set; }

        public Usuario(string nombreUsuario, string email, string password, Rol rol)
        {
            Id = s_ultId++;
            Nombre = new NombreUsuario(nombreUsuario);
            Email = new EmailUsuario(email);
            Password = new PasswordUsuario(password);
            Rol = rol;
            Validar();
        }

        public Usuario(){}

        public Usuario(int id)
        {
            Id = s_ultId++;
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