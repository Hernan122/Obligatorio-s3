using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio <Usuario>
    {
        Usuario FindByEmailAndPassword(Usuario usuario);
        Usuario FindByEmail(Usuario usuario);
        Usuario FindByEmail(string email);
    }
}