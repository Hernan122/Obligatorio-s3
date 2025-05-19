using System.ComponentModel;

namespace MVC.Models.Envio.Urgente
{
    public class EditarUrgenteViewModel : EditarEnvioViewModel
    {
        [DisplayName("Direccion Postal")]
        public int DireccionPostal { get; set; }

        [DisplayName("Entrega Eficiente")]
        public bool EntregaEficiente { get; set; }
    }
}