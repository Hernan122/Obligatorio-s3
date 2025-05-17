namespace Compartido.DTOs.EnvioDTO.EnvioUrgenteDTO
{
    public class EditarUrgenteDTO : AltaEnvioDTO
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }
    }
}