using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAgencia : IRepositorio <Agencia>
    {
        public Agencia? FindByName(string nombre);
    }
}