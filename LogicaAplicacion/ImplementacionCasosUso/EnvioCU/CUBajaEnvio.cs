using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUBajaEnvio : IBajaEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUBajaEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }
        public void Ejecutar(int id)
        {
            RepoEnvios.Delete(id);
        }
    }
}