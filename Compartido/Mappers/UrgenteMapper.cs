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

        public static void UrgenteFromBajaUrgenteDTO()
        {

        }

        public static Urgente UrgenteFromEditarUrgenteDTO(EditarUrgenteDTO envioDTO)
        {
            Urgente comun = new Urgente()
            {
                Id = envioDTO.Id,
                NumeroTracking = envioDTO.NumeroTracking,
                PesoPaquete = envioDTO.PesoPaquete,
                Estado = envioDTO.Estado,
                ClienteId = envioDTO.ClienteId,
                FuncionarioId = envioDTO.FuncionarioId,
            };
            return comun;
        }

        public static void UrgenteFromVerDetalleUrgenteDTO()
        {

        }

        public static void UrgenteFromVerUrgenteDTO()
        {

        }

        public static VerDetallesUrgenteDTO UrgenteToVerDetallesUrgenteDTO(Urgente urgente)
        {
            return new VerDetallesUrgenteDTO()
            {
            };
        }

    }
}
