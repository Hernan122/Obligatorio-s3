using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUBuscarEnvioPorComentario : IBuscarEnvioPorComentario
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        
        public CUBuscarEnvioPorComentario(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public List<ListadoEnviosDTO> Ejecutar(string comentario)
        {
            IEnumerable<Envio> listado = RepoEnvios.BuscarEnviosPorComentario(comentario);
            if (!listado.Any())
            {
                throw new EnvioException("No hay envios con ese comentario");
            }
            List<ListadoEnviosDTO> listadodto = EnvioMapper.ListadoEnvioToListadoEnvioDTO(listado);
            return listadodto;
        }

    }
}