using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.EnvioDTO
{
    public class VerDetalleEnvioDTO
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public Estado Estado { get; set; }
        public int FuncionarioId { get; set; }
    }
}