using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioEF : IRepositorioEnvio
    {
        private DemoContext Contexto { get; set; }

        public RepositorioEnvioEF(DemoContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Envio item)
        {
            Envio envioTemp = FindByNumeroTracking(item.NumeroTracking, item.Id);
            if (envioTemp == null)
            {
                Contexto.Envios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EnvioException("Ya existe un Envio con ese Numero de Tracking");
            }
        }

        public void Delete(int id)
        {
            Envio envio = FindById(id);
            if (envio == null)
            {
                throw new EnvioException("No se ha encontrado al envio");
            }
            Contexto.Envios.Remove(envio);
            Contexto.SaveChanges();
        }

        public IEnumerable<Envio> FindAll()
        {
            return Contexto.Envios;
        }

        public IEnumerable<Envio> EnviosEnProceso()
        {
            return Contexto.Envios.Where(c => c.Estado == Estado.EN_PROCESO);
        }

        public Envio? FindById(int id)
        {
            return Contexto.Envios
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public void Update(Envio item)
        {
            Envio nuevoEnvio = FindById(item.Id);
            if (nuevoEnvio != null)
            {
                Contexto.Envios.Update(nuevoEnvio);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EnvioException("Ya existe un Envio con ese Numero de Tracking");
            }
        }

        public Envio? FindByNumeroTracking(string numeroTracking, int id)
        {
            return Contexto.Envios
                    .Where(c => c.NumeroTracking == numeroTracking && c.Id != id)
                    .FirstOrDefault();
        }

        public IEnumerable<Envio> FindAllEnviosConSeguimiento()
        {
            return Contexto.Envios
                .Include(c => c.Seguimientos);
        }

        public Envio? FindByNumeroTrackingSinId(string numeroTracking)
        {
            return Contexto.Envios
                .Where(c => c.NumeroTracking == numeroTracking)
                .Include(c => c.Seguimientos)
                .SingleOrDefault();
        }

        public Envio? FindEnvioAndSeguimientoById(int id)
        {
            return Contexto.Envios
                   .Where(c => c.Id == id)
                   .Include(c => c.Seguimientos)
                   .SingleOrDefault();
        }

        public List<Envio> ListadoEnviosDetalladosPorClienteId(int clienteId)
        {
            return Contexto.Envios
                .Where(c => c.Cliente.Id == clienteId
                && c.Seguimientos.OrderBy(c => c.Fecha).Any()).ToList();
        }

    }
}