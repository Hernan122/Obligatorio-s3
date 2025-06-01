using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comun : Envio, IEquatable<Comun>
    {
        public Agencia Agencia { get; set; }

        [ForeignKey("Agencia")]
        public int AgenciaId { get; set; }

        public Comun(
            int agenciaId, 
            int numeroTracking, 
            int pesoPaquete, 
            int clienteId, 
            int funcionarioId
        ) : base(numeroTracking, pesoPaquete, clienteId, funcionarioId) {
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