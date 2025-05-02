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
        public Usuario Funcionario { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }

        public Seguimiento(DateTime fecha, string comentario, Envio envio, Usuario funcionario) { 
            Fecha = fecha;
            Comentario = comentario;
            Envio = envio;
            Funcionario = funcionario;
        }

        public bool Equals(Seguimiento? other)
        {
            return Id == other.Id;
        }
    }
}