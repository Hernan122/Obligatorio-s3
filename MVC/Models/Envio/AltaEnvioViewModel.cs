using System.ComponentModel;

namespace MVC.Models.Envio
{
    public abstract class AltaEnvioViewModel
    {
        [DisplayName("Numero Tracking")]
        public string NumeroTracking { get; set; }

        [DisplayName("Peso del Paquete")]
        public int PesoPaquete { get; set; }

        [DisplayName("Email del Cliente")]
        public string EmailCliente { get; set; }
    }
}