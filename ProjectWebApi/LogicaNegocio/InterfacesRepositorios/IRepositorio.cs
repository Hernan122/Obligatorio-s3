namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio <I>
    {
        void Add(I item);
        IEnumerable<I> FindAll();

        I? FindById (int id);

        void Delete (int id);

        void Update (I item);
    }
}