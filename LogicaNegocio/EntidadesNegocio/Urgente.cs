using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : Envio, IEquatable<Urgente>
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }

        public Urgente() { }

        public Urgente(
            int direccionPostal,
            bool entregaEficiente,
            int numeroTracking,
            int pesoPaquete,
            Estado estado,
            int clienteId,
            int funcionarioId,
            int seguimientoId
        ) : base(numeroTracking, pesoPaquete, estado, clienteId, funcionarioId, seguimientoId)
        {
            DireccionPostal = direccionPostal;
            EntregaEficiente = entregaEficiente;
        }

        public bool Equals(Urgente? other)
        {
            return true;
        }

        public override void Validar()
        {
            base.Validar();
            if (DireccionPostal > 0)
            {
                throw new UrgenteException("Direccion Postal invalido");
            }
            if (DireccionPostal == null)
            {
                throw new UrgenteException("Entrega Eficiente null");
            }
        }
    }
}