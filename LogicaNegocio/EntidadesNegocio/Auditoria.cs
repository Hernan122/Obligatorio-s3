using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public Accion AccionRealizada { get; set; }
        public DateTime Fecha { get; set; }
        public int FuncionarioId { get; set; }

        private Auditoria() { }

        public Auditoria(string accion, DateTime fecha, int funcionarioId)
        {
            AccionRealizada = AsignarAccion(accion);
            Fecha = fecha;
            FuncionarioId = funcionarioId;
        }

        public Accion AsignarAccion(string accion)
        {
            foreach (Accion item in Enum.GetValues(typeof(Accion)))
            {
                if (accion == item.ToString())
                {
                    return item;
                }
            }
            throw new AuditoriaException("Accion no aceptada");
        }
    }
}