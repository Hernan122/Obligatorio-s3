namespace MVC.Models.Usuarios
{
    public class UsuarioViewModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public  Cargos Rol { get; set; } 
        public enum Cargos { Administrador, Funcionario, Cliente}

    }
}
