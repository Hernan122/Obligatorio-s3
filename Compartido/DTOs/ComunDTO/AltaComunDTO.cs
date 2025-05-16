namespace Compartido.DTOs.EnvioComunDTO
{
    public class AltaComunDTO
    {
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int SeguimientoId { get; set; }
        public int AgenciaId { get; set; }
    }
}