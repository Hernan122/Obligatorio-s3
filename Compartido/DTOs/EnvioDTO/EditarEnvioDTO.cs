namespace Compartido.DTOs.EnvioDTO
{
    public abstract class EditarEnvioDTO
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int SeguimientoId { get; set; }
    }
}