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

        public Agencia (int ubPos, int ub, UbicacionAgencia ubicacion, NombreAgencia nombre, int usuarioId)
        {
            UbPos = ubPos;
            Ubicacion = ubicacion;
            Nombre = nombre;
            UsuarioId = usuarioId;
            Nombre = nombre;
            Validar();
        }

        public void Validar()
        {

        }

        public bool Equals(Agencia? other)
        {
            return Id == other.Id;
        }
    }
}