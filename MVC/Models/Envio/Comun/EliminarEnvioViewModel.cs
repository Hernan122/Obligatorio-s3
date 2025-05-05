using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio.Comun
{
    public class EliminarEnvioUrgenteViewModel
    {
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public Estado Estado { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int SeguimientoId { get; set; }

        // Comun properties
        public int AgenciaId { get; set; }
    }
}
