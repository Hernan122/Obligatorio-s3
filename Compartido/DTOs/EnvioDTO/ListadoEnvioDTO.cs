namespace Compartido.DTOs.EnvioDTO
{
    public class ListadoEnvioDTO
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public int FuncionarioId { get; set; }
    }
}