using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUBuscarEnvio : IBuscarEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUBuscarEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }
        public VerDetallesEnvioDTO Ejecutar(int id)
        {
            Envio envio = RepoEnvios.FindById(id);
            VerDetallesEnvioDTO retornar = null;
            
            if (envio is Comun)
            {
                retornar = ComunMapper.ComunToVerDetallesComunDTO((Comun)envio);
            }
            else
            {
                retornar = UrgenteMapper.UrgenteToVerDetallesUrgenteDTO((Urgente)envio);
            }

            return retornar;
        }

    }
}
