using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Seguimiento : IEquatable<Seguimiento>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public Envio Envio { get; set; }

        [ForeignKey("Envio")]
        public int EnvioId { get; set; }

        public Usuario Funcionario { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }

        public Seguimiento(DateTime fecha, string comentario, int envioId, int funcionarioId) { 
            Fecha = fecha;
            Comentario = comentario;
            EnvioId = envioId;
            FuncionarioId = funcionarioId;
        }

        public Seguimiento() { }

        public bool Equals(Seguimiento? other)
        {
            return Id == other.Id;
        }
    }
}