using Compartido.DTOs.AgenciaDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject.Agencia;

namespace Compartido.Mappers
{
    public class AgenciaMapper
    {
        public static List<ListadoAgenciaDTO> ListadoAgenciaToListadoAgenciaDTO(List<Agencia> agencias)
        {
            List<ListadoAgenciaDTO> listado = new List<ListadoAgenciaDTO>();
            listado = agencias.Select(c => new ListadoAgenciaDTO()
            {
                Nombre = c.Nombre,
                UsuarioId = c.UsuarioId
            }).ToList();
            return listado;
        }

        public static Agencia AgenciaFromAltaAgenciaDTO(AltaAgenciaDTO agenciaDTO)
        {
            return new Agencia()
            {
                UbPos = agenciaDTO.UbPos,
                Ubicacion = new UbicacionAgencia(agenciaDTO.CoordenadasLatitud, agenciaDTO.CoordenadasLongitud),
                Nombre = agenciaDTO.Nombre,
                UsuarioId = agenciaDTO.UsuarioId
            };
        }
    }
}