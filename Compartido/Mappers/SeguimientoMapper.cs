using Compartido.DTOs.SeguimientoDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class SeguimientoMapper
    {
        public static Seguimiento SeguimientoFromAltaSeguimientoDTO(AltaSeguimientoDTO seguimientoDTO)
        {
            return new Seguimiento()
            {
                Fecha = seguimientoDTO.Fecha,
                Comentario = seguimientoDTO.Comentario,
                FuncionarioId = seguimientoDTO.FuncionarioId
            };
        }

        public static void SeguimientoFromBajaSeguimientoDTO()
        {

        }

        public static void SeguimientoFromEditarSeguimientoDTO()
        {

        }

        public static void SeguimientoFromVerDetalleSeguimientoDTO()
        {

        }

        public static void SeguimientoFromVerSeguimientoDTO()
        {

        }
    }
}
