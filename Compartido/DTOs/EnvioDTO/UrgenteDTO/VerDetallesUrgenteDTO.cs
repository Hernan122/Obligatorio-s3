namespace Compartido.DTOs.EnvioDTO.EnvioUrgenteDTO
{
    public class VerDetallesUrgenteDTO : AltaEnvioDTO
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }
    }
}