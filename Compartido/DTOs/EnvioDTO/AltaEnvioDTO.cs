using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.EnvioDTO
{
    public class AltaEnvioDTO
    {
        public int TipoEnvio { get; set; }
        public string EmailCliente { get; set; }
        public string DireccionPostal { get; set; }
        public int PesoPaquete { get; set; }
    }
}