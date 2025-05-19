using System.ComponentModel;

namespace MVC.Models.Envio.Comun
{
    public class EditarComunViewModel : EditarEnvioViewModel
    {
        [DisplayName("Nombre de la Agencia")]
        public string NombreAgencia { get; set; }
    }
}