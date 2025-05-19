namespace MVC.Models.Agencia
{
    public class AltaAgenciaViewModel
    {
        public int UbPos { get; set; }
        public int CoordenadasLatitud { get; set; }
        public int CoordenadasLongitud { get; init; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
    }
}