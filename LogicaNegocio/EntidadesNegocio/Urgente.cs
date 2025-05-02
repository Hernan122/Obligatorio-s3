using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : Envio, IEquatable<Urgente>
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }

        public Urgente() { }

        public bool Equals(Urgente? other)
        {
            return true;
        }

        public override void Validar()
        {

        }
    }
}