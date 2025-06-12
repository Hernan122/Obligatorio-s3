namespace LogicaNegocio.ExcepcionesEntidades
{
    public class AgenciaException : Exception
    {
        public AgenciaException() { }

        public AgenciaException(string message) : base(message) { }

        public AgenciaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
