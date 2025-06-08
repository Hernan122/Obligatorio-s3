namespace Compartido.DTOs.SeguimientoDTO
{
    public class AltaSeguimientoDTO
    {
        public DateTime Fecha { get; set; }
        public int FuncionarioId { get; set; }
        public string ? Comentario { get; set; } = "Ingresado en agencia de origen";
    }
}