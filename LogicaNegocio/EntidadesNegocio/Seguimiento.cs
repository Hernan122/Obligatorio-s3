using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Seguimiento : IEquatable<Seguimiento>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public Usuario Funcionario { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }

        public Seguimiento(DateTime fecha, string comentario, int funcionarioId) {
            Fecha = fecha;
            Comentario = comentario;
            FuncionarioId = funcionarioId;
        }

        private Seguimiento() { }

        public bool Equals(Seguimiento? other)
        {
            return Id == other.Id || Comentario == other.Comentario;
        }
    }
}