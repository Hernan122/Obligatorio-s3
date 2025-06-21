namespace MVC.Models.Envio
{
    public class ListadoEnviosDetalladosViewModel
    {
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
    }
}