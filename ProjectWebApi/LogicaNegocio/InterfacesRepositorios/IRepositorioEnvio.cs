using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        public Envio? FindByNumeroTracking(string numeroTracking, int id);
        public Envio? FindByNumeroTrackingSinId(string numeroTracking);
        public IEnumerable<Envio> EnviosEnProceso();
        public IEnumerable<Envio> FindAllEnviosConSeguimiento();
        public Envio? FindEnvioAndSeguimientoById(int id);
        public List<Envio> ListadoEnviosDetalladosPorClienteId(int clienteId);
    }
}