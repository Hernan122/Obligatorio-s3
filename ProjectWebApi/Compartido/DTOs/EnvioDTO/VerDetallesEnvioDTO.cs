namespace Compartido.DTOs.EnvioDTO
{
    public class VerDetallesEnvioDTO
    {
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        public int FuncionarioId { get; set; }
    }
}