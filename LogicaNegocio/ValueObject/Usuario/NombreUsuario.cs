using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.ValueObject.Usuario
{
    public record NombreUsuario
    {
        public string Valor { get; init; }
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
            if (Valor.Length < 8)
            {
                throw new UsuarioException("Valores deben ser mayores a 8");
            }
        }
    }
}