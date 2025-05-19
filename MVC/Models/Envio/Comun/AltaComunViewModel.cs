using System.ComponentModel;

namespace MVC.Models.Envio.Comun
{
    public class AltaComunViewModel : AltaEnvioViewModel
    {
        [DisplayName("Nombre de la Agencia")]
        public string NombreAgencia { get; set; }
    }
}