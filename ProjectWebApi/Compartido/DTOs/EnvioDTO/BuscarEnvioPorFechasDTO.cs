namespace Compartido.DTOs.EnvioDTO
{
    public class BuscarEnvioPorFechasDTO
    {
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
    }
}