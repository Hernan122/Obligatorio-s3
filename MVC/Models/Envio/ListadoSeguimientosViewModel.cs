namespace MVC.Models.Envio
{
    public class ListadoSeguimientosViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int FuncionarioId { get; set; }
    }
}