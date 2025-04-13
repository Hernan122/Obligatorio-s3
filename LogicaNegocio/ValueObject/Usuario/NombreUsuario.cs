using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.ValueObject.Usuario
{
    public record NombreUsuario
    {
        private string Valor { get; set; }
        public NombreUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new UsuarioException("Nombre obligatorio");
            }
        }

    }
}