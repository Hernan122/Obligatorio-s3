using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : Envio, IEquatable<Urgente>
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }

        private Urgente() { }
        public Urgente(
            int direccionPostal,
            bool entregaEficiente,
            string numeroTracking,
            int pesoPaquete,
            int clienteId,
            int funcionarioId
        ) : base(numeroTracking, pesoPaquete, clienteId, funcionarioId)
        {
            DireccionPostal = direccionPostal;
            EntregaEficiente = entregaEficiente;
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

        public bool Equals(Urgente? other)
        {
            return true;
        }
        
    }
}