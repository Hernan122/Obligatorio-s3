using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comun : Envio, IEquatable<Comun>
    {
        public Agencia Agencia { get; set; }

        [ForeignKey("Agencia")]
        public int AgenciaId { get; set; }

        private Comun() { }

        public Comun(
            int agenciaId, 
            string numeroTracking, 
            int pesoPaquete, 
            int clienteId, 
            int funcionarioId
        ) : base(numeroTracking, pesoPaquete, clienteId, funcionarioId) {
            AgenciaId = agenciaId;
        }

        public override void Validar()
        {
            base.Validar();
            if (AgenciaId < 0)
            {
                throw new EnvioException("Debe ingresar una Agencia valida");
            }
        }

        public bool Equals(Comun other)
        {
            return true;
        }
    }
}