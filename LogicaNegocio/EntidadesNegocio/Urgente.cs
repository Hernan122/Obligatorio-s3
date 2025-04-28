using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : IEquatable<Urgente>
    {
        public bool Equals(Urgente? other)
        {
            // return Nombre == other.Nombre;
            return true;
        }
    }
}