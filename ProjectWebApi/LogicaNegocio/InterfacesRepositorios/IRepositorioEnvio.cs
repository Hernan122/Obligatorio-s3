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
        public IEnumerable<Envio> ListadoEnviosDetallados(int clienteId);
        public Envio? ListadoSeguimientos(int envioId);
        public IEnumerable<Envio> BuscarEnviosPorFechas(DateOnly fechaInicio, DateOnly fechaFin, int estado=-1);
        public IEnumerable<Envio> BuscarEnviosPorComentario(string comentario);
    }
}