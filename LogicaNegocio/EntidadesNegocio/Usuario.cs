using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario : IEquatable<Usuario>
    {
        public int Id { get; set; }
        private static int s_ultId;
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }

        public Usuario(string nombreUsuario, string email, string password, Rol rol)
        {
            Id = s_ultId++;
            NombreUsuario = nombreUsuario;
            Email = email;
            Password = password;
            Rol = rol;
            Validar();
        }
        private Usuario()
        {

        }
        public Usuario(int id)
        {
            Id = s_ultId++;
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(NombreUsuario))
            {
                throw new UsuarioException("El nombre de usuario no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new UsuarioException("El email no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                throw new UsuarioException("La contraseña no puede estar vacía.");
            }
            if (Rol == null)
            {
                throw new UsuarioException("El rol no puede estar vacío.");
            }
        }

        public bool Equals(Usuario? other)
        {
            return NombreUsuario == other.NombreUsuario;
        }
    }
}