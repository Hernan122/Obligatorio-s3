using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUBuscarEnvioPorFechas : IBuscarEnvioPorFechas
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        
        public CUBuscarEnvioPorFechas(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public List<ListadoEnviosInfoRelevanteDTO> Ejecutar(int estado, BuscarEnvioPorFechasDTO envio)
        {
            IEnumerable<Envio> listado = RepoEnvios.BuscarEnviosPorFechas(envio.FechaInicio, envio.FechaFin, estado);
            if (!listado.Any())
            {
                throw new EnvioException("No hay envios con esos parametros");
            }

            List<ListadoEnviosInfoRelevanteDTO> listadodtos = EnvioMapper.ListadoEnviosToListadoEnviosInfoRelevanteDTO(listado);
            return listadodtos;
        }

    }
}