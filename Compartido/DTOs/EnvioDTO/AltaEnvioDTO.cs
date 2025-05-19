namespace Compartido.DTOs.EnvioDTO
{
    public abstract class AltaEnvioDTO
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public string EmailCliente { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime Fecha { get; set; }
    }
}