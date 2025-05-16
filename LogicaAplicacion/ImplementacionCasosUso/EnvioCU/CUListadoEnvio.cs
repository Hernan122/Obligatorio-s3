using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUListadoEnvio : IListadoEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUListadoEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public List<ListadoEnvioDTO> Ejecutar()
        {
            List<ListadoEnvioDTO> enviosDTO = new List<ListadoEnvioDTO>();
            List<Envio> envios = RepoEnvios.FindAll().ToList();
            enviosDTO = EnvioMapper.ListadoEnvioToListadoEnvioDTO(envios);
            return enviosDTO;
        }
    }
}