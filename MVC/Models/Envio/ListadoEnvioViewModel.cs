using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.Identity.Client;

namespace MVC.Models.Envio
{
    public class ListadoEnvioViewModel
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public Estado Estado { get; set; }
        public int FuncionarioId { get; set; }
    }
}