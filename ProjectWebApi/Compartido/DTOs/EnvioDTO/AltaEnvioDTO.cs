namespace Compartido.DTOs.EnvioDTO
{
    public abstract class AltaEnvioDTO
    {
        public string NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public string EmailCliente { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime Fecha { get; set; }
    }
}