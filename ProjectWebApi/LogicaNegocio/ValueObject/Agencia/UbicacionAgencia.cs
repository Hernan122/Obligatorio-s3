using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public record UbicacionAgencia
    {
        public int CoordenadasLatitud { get; private set; }
        public int CoordenadasLongitud { get; private set; }

        public UbicacionAgencia() { }

        public UbicacionAgencia(int coordenadasLatitud, int coordenadasLongitud)
        {
            CoordenadasLatitud = coordenadasLatitud;
            CoordenadasLongitud = coordenadasLongitud;
        }
    }
}