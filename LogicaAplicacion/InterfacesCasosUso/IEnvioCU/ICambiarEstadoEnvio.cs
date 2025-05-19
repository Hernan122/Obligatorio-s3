using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface ICambiarEstadoEnvio
    {
        void Ejecutar(int id, string type, AltaSeguimientoDTO seguimientoDTO);
    }
}