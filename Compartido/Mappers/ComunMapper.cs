using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class ComunMapper
    {
        public static Envio AltaComunFromAltaComunDTO(AltaEnvioDTO comunDTO)
        {
            Envio envio = null;
            return envio;
        }

        public static void ComunFromBajaComunDTO(BajaEnvioDTO comunDTO)
        {

        }

        public static Comun ComunFromEditarComunDTO(EditarEnvioDTO envioDTO)
        {
            Comun comun = new Comun()
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

        public static void ComunFromVerDetalleComunDTO(VerDetallesComunDTO comunDTO)
        {

        }
    }
}
