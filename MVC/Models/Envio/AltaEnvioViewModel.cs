using System.ComponentModel;
using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public class AltaEnvioViewModel
    {
        public int TipoEnvio { get; set; }
        public string EmailCliente { get; set; }
        public string DireccionPostal { get; set; }
        public int PesoPaquete { get; set; }
    }
}