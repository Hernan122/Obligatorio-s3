namespace LogicaNegocio.ExcepcionesEntidades
{
    public class EnvioException : Exception
    {
        public EnvioException() { }

        public EnvioException(string message) : base(message) { }

        public EnvioException(string message, Exception innerException) : base(message, innerException) { }
        
    }
}
