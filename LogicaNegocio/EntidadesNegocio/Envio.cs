using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Envio : IEquatable<Envio>
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public Estado Estado { get; set; } = Estado.EN_PROCESO;
        public Usuario Cliente { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Usuario Funcionario { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }

        public Seguimiento Seguimiento { get; set; }

        [ForeignKey("Seguimiento")]
        public int SeguimientoId { get; set; }

        //public enum Estado
        //{
        //    EnProceso,
        //    Finalizado,
        //}

        public Envio() { }

        public Envio (int numerotracking, int pesoPaquete, Estado estado, int clienteId, int funcionarioId, int seguimientoId)
        {
            NumeroTracking = numerotracking;
            PesoPaquete = pesoPaquete;
            Estado = estado;
            ClienteId = clienteId;
            FuncionarioId = funcionarioId;
            SeguimientoId = seguimientoId;
            Validar();
        }

        public Envio(int numeroTracking)
        {
            NumeroTracking = numeroTracking;
        }

        public virtual void Validar()
        {

        }

        public bool Equals(Envio? other)
        {
            return Id == other.Id;
        }
    }
}