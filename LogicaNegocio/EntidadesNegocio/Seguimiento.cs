using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Seguimiento : IEquatable<Seguimiento>
    {
        public int  Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public Envio Envio { get; set; }
        public Usuario usuario { get; set; }

        public Seguimiento(int id, DateTime fecha, string comentario, Envio envio, Usuario usuario ) { }

        public bool Equals(Seguimiento? other)
        {
            return Id == other.Id;
        }
    }
}