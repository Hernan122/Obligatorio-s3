using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUListadoEnviosDetallados : IListadoEnviosDetallados
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        
        public CUListadoEnviosDetallados(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public List<ListadoEnviosDetalladosDTO> Ejecutar(int clienteId)
        {
            List<Envio> envio = RepoEnvios.ListadoEnviosDetallados(clienteId).ToList();
            List<ListadoEnviosDetalladosDTO> listadoDTO = EnvioMapper.ListadoEnviosFromListadoEnviosDetalladosDTO(envio);
            return listadoDTO;
        }

    }
}