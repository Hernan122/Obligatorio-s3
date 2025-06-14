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
        
        private Seguimiento() { }

        public Seguimiento(DateTime fecha, string comentario, int funcionarioId) {
            Fecha = fecha;
            Comentario = comentario;
            FuncionarioId = funcionarioId;
        }

        public bool Equals(Seguimiento? other)
        {
            return Id == other.Id || Comentario == other.Comentario;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Fecha: {Fecha}, Comentario: {Comentario}, FuncionarioId: {FuncionarioId}";
        }
    }
}