namespace Compartido.DTOs.EnvioDTO
{
    public class AltaEnvioDTO
    {
        public string TipoEnvio { get; set; }
        public string EmailCliente { get; set; }
        public string DireccionPostal { get; set; }
        public int PesoPaquete { get; set; }
    }
}