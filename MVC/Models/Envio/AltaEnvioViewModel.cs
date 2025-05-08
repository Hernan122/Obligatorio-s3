using System.ComponentModel;
using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public class AltaEnvioViewModel
    {
        // RF: Tipo Envio
        public int TipoEnvio { get; set; }
        // RF: Email Cliente
        public string EmailCliente { get; set; }
        // RF: Direccion Postal
        public string DireccionPostal { get; set; }
        // RF: Peso Paquete
        public int PesoPaquete { get; set; }
    }
}