namespace LogicaNegocio.ExcepcionesEntidades
{
    public class SeguimientoException : Exception
    {
        public SeguimientoException() { }

        public SeguimientoException(string message) : base(message) { }

        public SeguimientoException(string message, Exception innerException) : base(message, innerException) { }
    }
}