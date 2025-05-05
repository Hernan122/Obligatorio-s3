using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public class AltaEnvioViewModel
    {
        public int NumeroTracking { get; set; }
        public Estado Estado { get; set; }
        public int FuncionarioId { get; set; }
        public int SeguimientoId { get; set; }
        public int TipoEnvio { get; set; }
        public string EmailCliente { get; set; }
        public string DireccionPostal { get; set; }
        public int PesoPaquete { get; set; }
    }
}