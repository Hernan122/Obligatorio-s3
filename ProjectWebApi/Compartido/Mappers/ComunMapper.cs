using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;

namespace Compartido.Mappers
{
    public class ComunMapper
    {
        public static Comun ComunFromAltaComunDTO(AltaEnvioDTO comunDTO, int clienteId, int agenciaId)
        {
            return new Comun
            (
                agenciaId,
                comunDTO.NumeroTracking,
                comunDTO.PesoPaquete,
                clienteId,
                comunDTO.FuncionarioId
            );
        }

        public static Comun ComunFromEditarComunDTO(EditarEnvioDTO envioDTO)
        {
            return new Comun
            (
                envioDTO.Id,
                envioDTO.NumeroTracking,
                envioDTO.PesoPaquete,
                envioDTO.ClienteId,
                envioDTO.FuncionarioId
            );
        }
    }
}
