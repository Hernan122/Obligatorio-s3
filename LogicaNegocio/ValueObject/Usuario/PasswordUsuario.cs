using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.ValueObject.Usuario
{
    [ComplexType]
    public record PasswordUsuario
    {
        public string Valor { get; set; }

        public PasswordUsuario() { }

        public PasswordUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar() 
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new UsuarioException("Contraseña obligatorio");
            }
            if (Valor.Length < 8)
            {
                throw new UsuarioException("Contraseña debe ser mayor a 8");
            }
            if (!Valor.Any(char.IsDigit))
            {
                throw new UsuarioException("Contraseña debe contener al menos un número");
            }
            if (!Valor.Any(char.IsUpper))
            {
                throw new UsuarioException("Contraseña debe contener al menos una letra mayúscula");
            }
        }

    }
}