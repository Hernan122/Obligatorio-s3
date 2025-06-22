using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {

        public static List<ListadoEnviosDTO> ListadoEnvioToListadoEnvioDTO(IEnumerable<Envio> envios)
        {
            List<ListadoEnviosDTO> enviosDTO = [];
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
            List<string> seguimientos = [];
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

        public static List<ListadoEnviosDetalladosDTO> ListadoEnviosFromListadoEnviosDetalladosDTO(IEnumerable<Envio> listado)
        {
            List<ListadoEnviosDetalladosDTO> listadoDTO = [];
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
            List<ListadoSeguimientosDTO> listadoDTO = [];
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
            List<ListadoEnviosInfoRelevanteDTO> listadonuevo = [];
            listadonuevo = listado.Select(c => new ListadoEnviosInfoRelevanteDTO()
            {
                Tipo = c is Comun ? "Comun" : "Urgente",
                NumeroTracking = c.NumeroTracking,
                Estado = c.Estado.ToString(),
                Fecha = c.Seguimientos.First().Fecha
            }).ToList();
            return listadonuevo;
        }

    }
}