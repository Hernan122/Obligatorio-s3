using System.ComponentModel;

namespace MVC.Models.Envio
{
    public abstract class EditarEnvioViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Numero Tracking")]
        public int NumeroTracking { get; set; }
        [DisplayName("Peso del Paquete")]
        public int PesoPaquete { get; set; }
        public DateTime Fecha { get; set; }
        public int FuncionarioId { get; set; }
    }
}