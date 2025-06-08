using Compartido.DTOs.AgenciaDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;

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
            return new Agencia
            (
                agenciaDTO.UbPos,
                agenciaDTO.CoordenadasLatitud, 
                agenciaDTO.CoordenadasLongitud,
                agenciaDTO.Nombre,
                agenciaDTO.UsuarioId
            );
        }
    }
}