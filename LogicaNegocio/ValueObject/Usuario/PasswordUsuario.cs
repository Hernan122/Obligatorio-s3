namespace LogicaNegocio.ValueObject.Usuario
{
    public record PasswordUsuario
    {
        private string Valor {  get; set; }

        public PasswordUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar() 
        {

        }
    }
}