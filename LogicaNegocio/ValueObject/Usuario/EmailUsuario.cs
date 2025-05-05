using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.ValueObject.Usuario
{
    [ComplexType]
    public record EmailUsuario
    {
        public string Valor { get; set; }

        public EmailUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new UsuarioException("Correo obligatorio");
            }
        }
    }
}