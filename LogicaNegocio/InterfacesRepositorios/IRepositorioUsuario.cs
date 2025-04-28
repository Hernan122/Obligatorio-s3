using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio <Usuario>
    {
        Usuario FindByEmailAndPassword(Usuario usuario);
    }
}