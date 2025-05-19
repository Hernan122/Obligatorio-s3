using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioEF : IRepositorioEnvio
    {
        private DemoContext Contexto { get; set; }

        public RepositorioEnvioEF(DemoContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Envio item)
        {
            if (!Contexto.Envios.Contains(item))
            {
                Contexto.Envios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EnvioException("Envio ya existente");
            }
        }

        public void Delete(int id)
        {
            Envio envio = FindById(id);
            if (envio == null)
            {
                throw new EnvioException("No se ha encontrado al envio");
            }
            Contexto.Envios.Remove(envio);
            Contexto.SaveChanges();
        }

        public IEnumerable<Envio> FindAll()
        {
            return Contexto.Envios;
        }

        public Envio FindById(int id)
        {
            return Contexto.Envios
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public void Update(Envio item)
        {
            Envio nuevoEnvio = FindById(item.Id);
            if (nuevoEnvio == null)
            {
                throw new EnvioException("No se encontro al envio");
            }
            Contexto.Envios.Update(nuevoEnvio);
            Contexto.SaveChanges();
        }
    }
}