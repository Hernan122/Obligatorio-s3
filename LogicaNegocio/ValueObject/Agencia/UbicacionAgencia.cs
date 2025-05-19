using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.ValueObject.Agencia
{
    [ComplexType]
    public record UbicacionAgencia
    {
        public int CoordenadasLatitud { get; init; }
        public int CoordenadasLongitud { get; init; }

        public UbicacionAgencia() { }

        public UbicacionAgencia(int coordenadasLatitud, int coordenadasLongitud)
        {
            CoordenadasLatitud = coordenadasLatitud;
            CoordenadasLongitud = coordenadasLongitud;
            Validar();
        }

        private void Validar()
        {

        }

    }
}