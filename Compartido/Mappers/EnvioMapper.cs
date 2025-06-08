using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
        public static List<ListadoEnvioDTO> ListadoEnvioFromListadoEnvioDTO(List<Envio> comunDTO)
        {
            List<ListadoEnvioDTO> enviosDTO = new List<ListadoEnvioDTO>();
            return enviosDTO;
        }

        public static List<ListadoEnvioDTO> ListadoEnvioToListadoEnvioDTO(List<Envio> envios)
        {
            List<ListadoEnvioDTO> enviosDTO = new List<ListadoEnvioDTO>();
            enviosDTO = envios.Select(envio => new ListadoEnvioDTO()
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                FuncionarioId = envio.FuncionarioId
            }).ToList();
            return enviosDTO;
        }

    }
}