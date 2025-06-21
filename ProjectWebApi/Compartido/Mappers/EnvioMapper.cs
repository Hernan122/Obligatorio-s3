using System.Reflection.Metadata.Ecma335;
using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;
using LogicaNegocio.EntidadesNegocio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
        public static List<ListadoEnviosDTO> ListadoEnvioFromListadoEnvioDTO(List<Envio> comunDTO)
        {
            List<ListadoEnviosDTO> enviosDTO = new List<ListadoEnviosDTO>();
            return enviosDTO;
        }

        public static List<ListadoEnviosDTO> ListadoEnvioToListadoEnvioDTO(List<Envio> envios)
        {
            List<ListadoEnviosDTO> enviosDTO = new List<ListadoEnviosDTO>();
            enviosDTO = envios.Select(envio => new ListadoEnviosDTO()
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

        public static ListadoEnviosDetalladosDTO EnvioToVerDetallesEnvioYSeguimientosDTO(Envio envio)
        {
            return new ListadoEnviosDetalladosDTO()
            {
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                FuncionarioId = envio.FuncionarioId,
                ClienteId = envio.ClienteId
            };
        }

        public static List<ListadoEnviosDetalladosDTO> ListadoEnviosFromListadoEnviosDetalladosDTO(List<Envio> listado)
        {
            List<ListadoEnviosDetalladosDTO> listadoDTO = new List<ListadoEnviosDetalladosDTO>();
            listadoDTO = listado.Select(envio => new ListadoEnviosDetalladosDTO()
            {
                Tipo = envio is Comun ? "Comun" : "Urgente",
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Estado = envio.Estado.ToString(),
                FuncionarioId = envio.FuncionarioId
            }).ToList();
            return listadoDTO;
        }

        public static List<ListadoSeguimientosDTO> EnvioToListadoSeguimientosDTO(Envio envio)
        {
            List<ListadoSeguimientosDTO> listadoDTO = new List<ListadoSeguimientosDTO>();
            listadoDTO = envio.Seguimientos.Select(seguimiento => new ListadoSeguimientosDTO()
            {
                Id = seguimiento.Id,
                Fecha = seguimiento.Fecha,
                Comentario = seguimiento.Comentario,
                FuncionarioId = seguimiento.FuncionarioId
            }).ToList();
            return listadoDTO;
        }

        public static List<ListadoEnviosInfoRelevanteDTO> ListadoEnviosToListadoEnviosInfoRelevanteDTO(IEnumerable<Envio> listado)
        {
            List<ListadoEnviosInfoRelevanteDTO> listadonuevo = null;

            listadonuevo = listado.Select(c => new ListadoEnviosInfoRelevanteDTO()
            {
                Tipo = c is Comun ? "Comun" : "Urgente",
                NumeroTracking = c.NumeroTracking,
                Estado = c.Estado.ToString()
            }).ToList();

            return listadonuevo;
        }

    }
}