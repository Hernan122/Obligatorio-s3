using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public abstract class AltaEnvioViewModel
    {
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public string EmailCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int FuncionarioId { get; set; }
        
    }
}