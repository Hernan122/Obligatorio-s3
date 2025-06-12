using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public record PasswordUsuario
    {
        public string Valor { get; private set; }

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
                throw new UsuarioException("Contraseña obligatoria");
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