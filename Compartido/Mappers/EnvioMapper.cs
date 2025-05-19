using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
        public static Comun ComunFromEditarComunDTO(EditarComunDTO envioDTO)
        {
            Comun envio = new Comun()
            {
                Id = envioDTO.Id,
                NumeroTracking = envioDTO.NumeroTracking,

            };
            return envio;
        }

        public static VerDetallesComunDTO ComunToComunDTO(Comun envio)
        {
            VerDetallesComunDTO envioComun = new VerDetallesComunDTO()
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                PesoPaquete = envio.PesoPaquete,
                Estado = envio.Estado,
                ClienteId = envio.ClienteId,
                FuncionarioId = envio.FuncionarioId,
            };
            return envioComun;
        }

        public static VerDetallesUrgenteDTO UrgenteToUrgenteDTO(Urgente envio)
        {
            VerDetallesUrgenteDTO envioComun = new VerDetallesUrgenteDTO()
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                PesoPaquete = envio.PesoPaquete,
                Estado = envio.Estado,
                ClienteId = envio.ClienteId,
                FuncionarioId = envio.FuncionarioId,
                DireccionPostal = envio.DireccionPostal,
                EntregaEficiente = envio.EntregaEficiente
            };
            return envioComun;
        }

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
                Estado = envio.Estado,
                FuncionarioId = envio.FuncionarioId
            }).ToList();
            return enviosDTO;
        }
    }
}