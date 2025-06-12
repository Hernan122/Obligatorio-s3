using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUBuscarEnvioPorId : IBuscarEnvioPorId
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        
        public CUBuscarEnvioPorId(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public VerDetallesEnvioDTO Ejecutar(int id)
        {
            Envio envio = RepoEnvios.FindById(id);
            if (envio == null)
            {
                throw new EnvioException("No se encontro el envio");
            }

            VerDetallesEnvioDTO dto = EnvioMapper.EnvioToVerDetallesEnvioDTO(envio);
            return dto;
        }
    }
}