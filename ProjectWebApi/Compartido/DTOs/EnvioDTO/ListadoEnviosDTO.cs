namespace Compartido.DTOs.EnvioDTO
{
    public class ListadoEnviosDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        public int FuncionarioId { get; set; }
    }
}