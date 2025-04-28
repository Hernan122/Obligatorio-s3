using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Envio : IEquatable<Envio>
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public int PesoPaquete { get; set; }

        public Envio (int Id, int numerotracking, int pesoPaquete)
        {
            Id = Id;
        }

        public Envio(int numeroTracking)
        {
            NumeroTracking = numeroTracking;
        }

        public bool Equals(Envio? other)
        {
            return Id == other.Id;
        }
    }

    }

