using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioSeguimientoEF : IRepositorioSeguimiento
    {
        private DemoContext Contexto { get; set; }

        public RepositorioSeguimientoEF(DemoContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario item)
        {
            throw new NotImplementedException();
        }
    }
}
