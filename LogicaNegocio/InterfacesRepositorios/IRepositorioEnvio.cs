using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        public Envio FindByNumeroTracking(string numeroTracking, int id);
        public IEnumerable<Envio> EnviosEnProceso();
    }
}