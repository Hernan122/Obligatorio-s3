namespace Compartido.DTOs.EnvioDTO.UrgenteDTO
{
    public class VerDetallesUrgenteDTO : VerDetallesEnvioDTO
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }
    }
}