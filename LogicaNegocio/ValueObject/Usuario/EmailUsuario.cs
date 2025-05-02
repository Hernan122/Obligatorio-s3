using System.ComponentModel.DataAnnotations.Schema;

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

        }
    }
}