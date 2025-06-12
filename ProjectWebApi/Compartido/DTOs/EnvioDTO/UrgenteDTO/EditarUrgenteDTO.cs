namespace Compartido.DTOs.EnvioDTO.UrgenteDTO
{
    public class EditarUrgenteDTO : EditarEnvioDTO
    {
        public int DireccionPostal { get; set; }
        public bool EntregaEficiente { get; set; }
    }
}