using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class ComunMapper
    {
        public static Comun ComunFromAltaComunDTO(AltaEnvioDTO comunDTO)
        {
            return new Comun()
            {
                NumeroTracking = comunDTO.NumeroTracking,
                PesoPaquete = comunDTO.PesoPaquete,
                FuncionarioId = comunDTO.FuncionarioId,
            };
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
