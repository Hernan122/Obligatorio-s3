using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.DTOs.SeguimientoDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUObtenerEnvioPorTracking : IObtenerEnvioPorTracking
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        private IRepositorioUsuario RepoUsuario { get; set; }
        private IRepositorioAgencia RepoAgencia { get; set; }

        public CUObtenerEnvioPorTracking(IRepositorioEnvio repoEnvios, IRepositorioUsuario repoUsuario, IRepositorioAgencia repoAgencia)
        {
            RepoEnvios = repoEnvios;
            RepoUsuario = repoUsuario;
            RepoAgencia = repoAgencia;
        }

        public VerDetallesEnvioDTO Ejecutar(int numeroTracking)
        {
            Envio envio = RepoEnvios.FindByNumeroTracking(numeroTracking);
            VerDetallesEnvioDTO envioDTO = null;

            if (envio is Comun)
            {
                envioDTO = ComunMapper.ComunToVerDetallesComunDTO((Comun)envio);
            }
            else
            {
                envioDTO = UrgenteMapper.UrgenteToVerDetallesUrgenteDTO((Urgente)envio);
            }

            return envioDTO;
        }
    }
}