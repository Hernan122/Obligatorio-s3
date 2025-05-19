using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        public Envio FindByNumeroTracking(int numeroTracking);
    }
}