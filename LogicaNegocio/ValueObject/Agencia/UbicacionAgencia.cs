using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.ValueObject.Agencia
{
    [ComplexType]
    public record UbicacionAgencia
    {
        public int CoordenadasLatitud { get; init; }
        public int CoordenadasLongitud { get; init; }
    }
}