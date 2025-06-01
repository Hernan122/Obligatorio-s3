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

        public List<Seguimiento> Seguimientos = new List<Seguimiento>();

        protected Envio() { }

        public Envio (int numerotracking, int pesoPaquete, int clienteId, int funcionarioId)
        {
            NumeroTracking = numerotracking;
            PesoPaquete = pesoPaquete;
            ClienteId = clienteId;
            FuncionarioId = funcionarioId;
            Validar();
        }

        public virtual void Validar()
        {
            if (NumeroTracking <= 0)
            {
                throw new EnvioException("Numero de Tracking invalido");
            }
            if (PesoPaquete <= 0)
            {
                throw new EnvioException("Peso invalido");
            }
        }

        public bool Equals(Envio? other)
        {
            return Id == other.Id;
        }
    }
}