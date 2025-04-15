namespace LogicaNegocio.ValueObject.Usuario
{
    public record PasswordUsuario
    {
        public string Valor {  get; set; }

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