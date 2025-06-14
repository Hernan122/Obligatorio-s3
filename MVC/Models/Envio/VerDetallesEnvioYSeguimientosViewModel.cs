namespace MVC.Models.Envio
{
    public class VerDetallesEnvioYSeguimientosViewModel
    {
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public string Seguimientos { get; set; }
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
    }
}