using Compartido.DTOs.AgenciaDTO;
using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IAltaAgencia
    {
        void Ejecutar(AltaAgenciaDTO agenciaDTO);
    }
}