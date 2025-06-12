namespace Compartido.DTOs.EnvioDTO.UrgenteDTO
{
    public class AltaUrgenteDTO : AltaEnvioDTO
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }
    }
}