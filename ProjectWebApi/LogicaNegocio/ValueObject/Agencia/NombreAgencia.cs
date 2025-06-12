using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public record NombreAgencia
    {
        public string Valor { get; private set; }

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