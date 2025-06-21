using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUListadoSeguimientos : IListadoSeguimientos
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUListadoSeguimientos(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public List<ListadoSeguimientosDTO> Ejecutar(int envioId)
        {
            Envio envio = RepoEnvios.ListadoSeguimientos(envioId);
            if (envio == null)
            {
                throw new EnvioException("Envio null");
            }

            List<ListadoSeguimientosDTO> seguimientos = EnvioMapper.EnvioToListadoSeguimientosDTO(envio);
            return seguimientos;
        }

    }
}