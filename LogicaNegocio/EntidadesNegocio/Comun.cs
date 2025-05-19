using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comun : Envio, IEquatable<Comun>
    {
        public Agencia Agencia { get; set; }

        [ForeignKey("Agencia")]
        public int AgenciaId { get; set; }

        public Comun() { }

        public Comun(
            int agenciaId, 
            int numeroTracking, 
            int pesoPaquete, 
            Estado estado, 
            int clienteId, 
            int funcionarioId
        ) : base(numeroTracking, pesoPaquete, estado, clienteId, funcionarioId) {
            AgenciaId = agenciaId;
        }

        public override void Validar()
        {
            base.Validar();
        }

        public bool Equals(Comun other)
        {
            return true;
        }
    }
}