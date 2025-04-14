namespace LogicaNegocio.ValueObject.Usuario
{
    public record EmailUsuario
    {
        private string Valor { get; set; }

        public EmailUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {

        }
    }
}