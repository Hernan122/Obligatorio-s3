using Compartido.DTOs.SeguimientoDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class SeguimientoMapper
    {
        public static Seguimiento SeguimientoFromAltaSeguimientoDTO(AltaSeguimientoDTO seguimientoDTO)
        {
            return new Seguimiento
            (
                seguimientoDTO.Fecha,
                seguimientoDTO.Comentario,
                seguimientoDTO.FuncionarioId
            );
        }
    }
}
