using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;


namespace LogicaNegocio.EntidadesNegocio
{
    internal class Seguimiento
    {
        public int  Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public Envio Envio { get; set; }
        public Usuario usuario { get; set; }

        public Seguimiento(int id, DateTime fecha, string comentario, Envio envio, Usuario usuario ) { }
    }
}
