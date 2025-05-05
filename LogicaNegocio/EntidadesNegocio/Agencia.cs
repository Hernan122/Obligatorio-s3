using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Agencia;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Agencia : IEquatable<Agencia>
    {
        public int Id { get; set; }
        public int UbPos { get; set; }
        public UbicacionAgencia Ubicacion { get; set; }
        public NombreAgencia Nombre {  get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Agencia (int ubPos, int ubicacionLatitud, int ubicacionLongitud, string nombre, int usuarioId)
        {
            UbPos = ubPos;
            Ubicacion = new UbicacionAgencia(ubicacionLatitud, ubicacionLongitud);
            Nombre = new NombreAgencia(nombre);
            UsuarioId = usuarioId;
            Validar();
        }

        public Agencia() {}

        public void Validar()
        {

        }

        public bool Equals(Agencia? other)
        {
            return Id == other.Id;
        }
    }
}