using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioEF : IRepositorioEnvio
    {

        private DemoContext Contexto { get; set; }

        public void Add(Envio item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> FindAll()
        {
            throw new NotImplementedException();
        }

        public Envio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Envio item)
        {
            throw new NotImplementedException();
        }
    }
}