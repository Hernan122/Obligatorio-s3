using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public class VerDetallesEnvioViewModel
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