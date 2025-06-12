using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        public int Id { get; set; }
        public Rol Rol { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public PasswordUsuario Password { get; set; }
        public IEnumerable<Auditoria> Auditorias { get; set; } = new List<Auditoria>();

        private Usuario() { }

        public Usuario(string nombre, string email, string password, string rol)
        {
            Nombre = nombre;
            Email = email;
            Password = new PasswordUsuario(password);
            Rol = AsignarRol(rol);
            Validar();
        }

        private Rol AsignarRol(string rol)
        {
            foreach (Rol item in Enum.GetValues(typeof(Rol)))
            {
                if (item.ToString() == rol)
                {
                    return item;
                }
            }
            throw new UsuarioException("No existe ese rol");
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new UsuarioException("Nombre vacio no es aceptable");
            }
            if (Rol == null)
            {
                throw new UsuarioException("Usuario debe tener al menos un rol");
            }
        }
        
        //public bool Equals(Usuario? other)
        //{
        //    return Email == other.Email;
        //}
    }
}