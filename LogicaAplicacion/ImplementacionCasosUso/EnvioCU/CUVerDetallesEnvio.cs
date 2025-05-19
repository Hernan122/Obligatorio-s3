using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUVerDetallesEnvio : IVerDetallesEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUVerDetallesEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }
        public VerDetallesEnvioDTO Ejecutar(int id)
        {
            Envio envio = RepoEnvios.FindById(id);
            if (envio == null)
            {
                throw new ArgumentNullException("Objeto null");
            }

            VerDetallesEnvioDTO envioDTO = null;

            if (envio is Comun)
            {
                envioDTO = EnvioMapper.ComunToComunDTO((Comun)envio);
            }
            else
            {
                envioDTO = EnvioMapper.UrgenteToUrgenteDTO((Urgente)envio);
            }

            return envioDTO;
        }
    }
}