using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class UrgenteMapper
    {
        public static Envio AltaUrgenteFromAltaUrgenteDTO(AltaUrgenteDTO envio)
        {
            return null;
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

    }
}
