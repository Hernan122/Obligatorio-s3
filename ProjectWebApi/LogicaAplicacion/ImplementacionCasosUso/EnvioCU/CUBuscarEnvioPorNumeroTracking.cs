using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUBuscarEnvioPorNumeroTracking : IBuscarEnvioPorNumeroTracking
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        
        public CUBuscarEnvioPorNumeroTracking(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public ListadoEnviosDetalladosDTO Ejecutar(string numeroTracking)
        {
            Envio envio = RepoEnvios.FindByNumeroTrackingSinId(numeroTracking);
            if (envio == null)
            {
                throw new EnvioException("No se encontro el envio");
            }

            ListadoEnviosDetalladosDTO dto = EnvioMapper.EnvioToVerDetallesEnvioYSeguimientosDTO(envio);
            return dto;
        }
    }
}