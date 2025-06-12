﻿namespace LogicaNegocio.ExcepcionesEntidades
{
    public class AuditoriaException : Exception
    {
        public AuditoriaException() { }

        public AuditoriaException(string message) : base(message) { }

        public AuditoriaException(string message, Exception innerException) : base(message, innerException) { }
    }
}