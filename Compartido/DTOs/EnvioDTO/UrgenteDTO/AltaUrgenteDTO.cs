namespace Compartido.DTOs.EnvioDTO.EnvioUrgenteDTO
{
    public class AltaUrgenteDTO : AltaEnvioDTO
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }
    }
}