using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IObtenerEnvioPorTracking
    {
        VerDetallesEnvioDTO Ejecutar(int numeroTracking);
    }
}