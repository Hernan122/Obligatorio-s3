using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUListadoEnvios : IListadoEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUListadoEnvios(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public List<ListadoEnviosDTO> Ejecutar()
        {
            List<ListadoEnviosDTO> enviosDTO = new List<ListadoEnviosDTO>();
            List<Envio> envios = RepoEnvios.FindAllEnviosConSeguimiento().ToList();
            enviosDTO = EnvioMapper.ListadoEnvioToListadoEnvioDTO(envios);
            return enviosDTO;
        }
    }
}