using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.EnvioDTO
{
    public abstract class VerDetallesEnvioDTO
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public Estado Estado { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int SeguimientoId { get; set; }
    }
}