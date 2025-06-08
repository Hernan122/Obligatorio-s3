using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class UrgenteMapper
    {
        public static Urgente UrgenteFromAltaUrgenteDTO(AltaUrgenteDTO envioDTO, int clienteId)
        {
            return new Urgente
            (
                envioDTO.DireccionPostal,
                envioDTO.EntregaEficiente,
                envioDTO.NumeroTracking,
                envioDTO.PesoPaquete,
                clienteId,
                envioDTO.FuncionarioId
            );
        }
    }
}
