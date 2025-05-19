using System.ComponentModel;

namespace MVC.Models.Envio.Comun
{
    public class VerDetallesComunViewModel : VerDetallesEnvioViewModel
    {
        [DisplayName("Nombre de la Agencia")]
        public string NombreAgencia { get; set; }
    }
}