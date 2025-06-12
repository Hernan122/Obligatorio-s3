using Compartido.DTOs.EnvioDTO;
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
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                Comentario = envio.Seguimientos.ToList()[envio.Seguimientos.Count()-1].Comentario,
                FuncionarioId = envio.FuncionarioId
            }).ToList();
            return enviosDTO;
        }

        public static VerDetallesEnvioDTO EnvioToVerDetallesEnvioDTO(Envio envio)
        {
            return new VerDetallesEnvioDTO()
            {
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                Comentario = envio.Seguimientos.ToList()[envio.Seguimientos.Count() - 1].Comentario,
                FuncionarioId = envio.FuncionarioId
            };
        }

    }
}