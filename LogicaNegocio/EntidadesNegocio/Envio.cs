using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
     public class Envio
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }
    


        public Envio (int Id, int numerotracking, int pesoPaquete)
        {
            Id = Id;
            ;
        }

        public Envio(int numeroTracking)
        {
            NumeroTracking = numeroTracking;
        }
    }

    }

