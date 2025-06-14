using System.Reflection.Metadata.Ecma335;
using Compartido.DTOs.EnvioDTO;
using LogicaNegocio.EntidadesNegocio;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<string> seguimientos = new List<string>();
            foreach (Seguimiento item in envio.Seguimientos.ToList())
            {
                seguimientos.Add($"{item.Comentario}");
            }
            return new VerDetallesEnvioDTO()
            {
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                Comentario = string.Join(", ", seguimientos),
                FuncionarioId = envio.FuncionarioId
            };
        }

        public static VerDetallesEnvioYSeguimientosDTO EnvioToVerDetallesEnvioYSeguimientosDTO(Envio envio)
        {
            List<string> seguimientos = new List<string>();
            foreach (Seguimiento item in envio.Seguimientos.ToList())
            {
                seguimientos.Add("{" + item + "}");
            }

            return new VerDetallesEnvioYSeguimientosDTO()
            {
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                Seguimientos = string.Join("\n ", seguimientos),
                FuncionarioId = envio.FuncionarioId,
                ClienteId = envio.ClienteId
            };
        }

        public static List<VerDetallesEnvioYSeguimientosDTO> ListadoEnviosFromListadoEnviosDetalladosDTO(List<Envio> listado)
        {
            List<VerDetallesEnvioYSeguimientosDTO> listadoDTO = new List<VerDetallesEnvioYSeguimientosDTO>();
            listadoDTO = listado.Select(envio => new VerDetallesEnvioYSeguimientosDTO()
            {
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                Seguimientos = string.Join("\n ", envio.Seguimientos),
                FuncionarioId = envio.FuncionarioId
            }).ToList();
            return listadoDTO;
        }

    }
}