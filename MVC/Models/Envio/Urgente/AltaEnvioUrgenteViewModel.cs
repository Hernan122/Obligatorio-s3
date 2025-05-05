using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio.Urgente
{
    public class AltaEnvioViewModel
    {
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public Estado Estado { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int SeguimientoId { get; set; }
        
        // Urgente properties
        public int DireccionPostal { get; set; }
        public int EntregaEficiente { get; set; }
    }
}