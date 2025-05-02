using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUrgenteEF : IRepositorioUrgente
    {
        private DemoContext Contexto { get; set; }

        public RepositorioUrgenteEF(DemoContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Urgente item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Urgente> FindAll()
        {
            throw new NotImplementedException();
        }

        public Urgente FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Urgente item)
        {
            throw new NotImplementedException();
        }
    }
}