using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public abstract class VerDetallesEnvioViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        [DisplayName("Peso del paquete")]
        public int PesoPaquete { get; set; }
        public Estado Estado { get; set; }
        [DisplayName("Cliente que realizo el envio")]
        public int ClienteId { get; set; }
        [DisplayName("Envio creado por funcionario:")]
        public int FuncionarioId { get; set; }
        [DisplayName("Id del seguimiento")]
        public int SeguimientoId { get; set; }
    }
}