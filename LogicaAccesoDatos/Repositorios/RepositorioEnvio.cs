using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private List <Envio> Envios = new List <Envio>();

        public void Add (Envio envio)
        {
            if (Envios.Contains(envio))
            {
                Envios.Add(envio);
            }
            else
            {
                throw new EnvioException("Ya existe un envio asi");
            }
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
