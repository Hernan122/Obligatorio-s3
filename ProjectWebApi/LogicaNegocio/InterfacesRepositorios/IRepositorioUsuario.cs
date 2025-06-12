using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio <Usuario>
    {
        Usuario FindByEmailAndPassword(string email, string password);
        Usuario FindByEmail(string email);
        Usuario FindByRepeatedEmail(string email, int id);
    }
}