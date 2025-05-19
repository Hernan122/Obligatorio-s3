using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUAltaEnvio : IAltaEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUAltaEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public void Ejecutar(AltaEnvioDTO envioDTO)
        {
            Envio envio = null;
            if (envioDTO is AltaComunDTO)
            {
                envio = ComunMapper.AltaComunFromAltaComunDTO((AltaComunDTO)envioDTO);
            }
            else if (envioDTO is AltaUrgenteDTO)
            {
                envio = UrgenteMapper.AltaUrgenteFromAltaUrgenteDTO((AltaUrgenteDTO)envioDTO);
            }
            else
            {
                throw new EnvioException("No existe ese tipo de envio");
            }
             RepoEnvios.Add(envio);
        }
    }
}