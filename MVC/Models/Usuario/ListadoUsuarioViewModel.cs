using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Usuario
{
    public class ListadoUsuarioViewModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public int IdEncargado { get; set; }
    }
}