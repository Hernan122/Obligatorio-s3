using Compartido.DTOs.AuditoriaDTO;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
    public class AuditoriaMapper
    {
        public static Auditoria AuditoriaFromAuditoriaDTO(AuditoriaDTO auditoriaDTO)
        {
            return new Auditoria
            (
                auditoriaDTO.AccionRealizada.ToString(),
                auditoriaDTO.Fecha,
                auditoriaDTO.FuncionarioId
            );
        }
    }
}