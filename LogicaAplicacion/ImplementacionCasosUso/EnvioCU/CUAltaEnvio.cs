using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioComunDTO;
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

        // Inyección de dependencia
        public CUAltaEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public void Ejecutar(AltaEnvioDTO envioDTO, int tipoEnvio)
        {
            Envio envio = null;
            if (tipoEnvio == 0)
            {
                envio = ComunMapper.AltaComunFromAltaComunDTO(envioDTO);
            }
            else if (tipoEnvio == 1)
            {
                envio = UrgenteMapper.AltaUrgenteFromAltaUrgenteDTO(envioDTO);
            }
            else
            {
                throw new EnvioException("No existe ese tipo de envio");
            }
             RepoEnvios.Add(envio);
        }

    }
}