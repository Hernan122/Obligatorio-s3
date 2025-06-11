using System.ComponentModel;

namespace MVC.Models.Envio
{
    public class ListadoEnvioViewModel
    {
        public string Tipo { get; set; }
        [DisplayName("EnvioId")]
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        [DisplayName("FuncionarioId")]
        public int FuncionarioId { get; set; }
    }
}