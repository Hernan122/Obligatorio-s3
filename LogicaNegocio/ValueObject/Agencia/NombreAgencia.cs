using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.ValueObject.Agencia
{
    [ComplexType]
    public record NombreAgencia
    {
        public string Valor { get; init; }

        public NombreAgencia() { }

        public NombreAgencia(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new AgenciaException("Nombre no valido");
            }
        }

    }
}