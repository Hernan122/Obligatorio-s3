using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.EnvioDTO
{
    public abstract class AltaEnvioDTO
    {
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public string EmailCliente { get; set; }
        public int SeguimientoId { get; set; }
        public int FuncionarioId { get; set; }
    }
}