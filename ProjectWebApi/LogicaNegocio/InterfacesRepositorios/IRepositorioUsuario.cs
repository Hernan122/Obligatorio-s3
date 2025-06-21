using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio <Usuario>
    {
        public Usuario? FindByEmailAndPassword(string email, string password);
        public Usuario? FindByEmail(string email);
        public Usuario? FindByRepeatedEmail(string email, int id);
    }
}