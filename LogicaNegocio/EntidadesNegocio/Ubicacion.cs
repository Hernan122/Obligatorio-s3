using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Ubicacion : IEquatable<Ubicacion>
    {
        public bool Equals(Ubicacion? other)
        {
            // return Nombre == other.Nombre;
            return true;
        }
    }
}