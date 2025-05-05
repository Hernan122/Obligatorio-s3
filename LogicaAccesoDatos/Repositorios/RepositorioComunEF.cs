using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioComunEF : IRepositorioEnvioComun
    {
        private DemoContext Contexto { get; set; }

        public RepositorioComunEF(DemoContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Comun item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comun> FindAll()
        {
            throw new NotImplementedException();
        }

        public Comun FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comun item)
        {
            throw new NotImplementedException();
        }
    }
}