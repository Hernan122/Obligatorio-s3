using System.ComponentModel;

namespace MVC.Models.Envio.Urgente
{
    public class VerDetallesUrgenteViewModel : VerDetallesEnvioViewModel
    {
        [DisplayName("Direccion Postal")]
        public int DireccionPostal { get; set; }

        [DisplayName("EntregaEficiente")]
        public bool EntregaEficiente { get; set; }
    }
}