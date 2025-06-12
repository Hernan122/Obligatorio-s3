namespace LogicaNegocio.ExcepcionesEntidades
{
    public class UrgenteException : Exception
    {
        public UrgenteException() { }

        public UrgenteException(string message) : base(message) { }

        public UrgenteException(string message, Exception innerException) : base(message, innerException) { }
    }
}