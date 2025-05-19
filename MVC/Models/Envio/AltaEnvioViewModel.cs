using System.ComponentModel;

namespace MVC.Models.Envio
{
    public abstract class AltaEnvioViewModel
    {
        [DisplayName("Numero Tracking")]
        public int NumeroTracking { get; set; }

        [DisplayName("Peso del Paquete")]
        public int PesoPaquete { get; set; }

        [DisplayName("Email del Cliente")]
        public string EmailCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int FuncionarioId { get; set; }
        
    }
}