﻿namespace Compartido.DTOs.EnvioDTO
{
    public class ListadoEnviosDetalladosDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
    }
}