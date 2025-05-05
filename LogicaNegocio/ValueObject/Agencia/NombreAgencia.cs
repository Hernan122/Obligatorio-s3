using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.ValueObject.Agencia
{
    [ComplexType]
    public record NombreAgencia
    {
        public string Valor { get; init; }

        public NombreAgencia(string valor)
        {
            Valor = valor;
            Validar();
        }

        public void Validar()
        {

        }
    }
}