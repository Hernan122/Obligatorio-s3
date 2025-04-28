using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Agencia : IEquatable<Agencia>
    {
        public int UbPos { get; set; }
        public int Id { get; set; }

        public bool Equals(Agencia? other)
        {
            return Id == other.Id;
        }
    }
}