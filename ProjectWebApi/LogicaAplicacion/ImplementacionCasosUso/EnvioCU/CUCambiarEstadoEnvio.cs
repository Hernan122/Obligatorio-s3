using Compartido.DTOs.SeguimientoDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUCambiarEstadoEnvio : ICambiarEstadoEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUCambiarEstadoEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }
        public void Ejecutar(int id, string type, AltaSeguimientoDTO seguimientoDTO)
        {
            Envio envio = RepoEnvios.FindById(id);
            if (envio == null)
            {
                throw new EnvioException("Envio inexistente");
            }

            seguimientoDTO.Comentario = type;

            Seguimiento seguimiento = SeguimientoMapper.SeguimientoFromAltaSeguimientoDTO(seguimientoDTO);
            List<Seguimiento> seguimientos = envio.Seguimientos.ToList();
            seguimientos.Add(seguimiento);
            envio.Seguimientos = seguimientos;
            RepoEnvios.Update(envio);
        }
    }
}