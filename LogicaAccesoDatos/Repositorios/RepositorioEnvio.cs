using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio
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

    }
}
