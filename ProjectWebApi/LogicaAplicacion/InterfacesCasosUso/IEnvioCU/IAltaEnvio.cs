using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.SeguimientoDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IAltaEnvio
    {
        void Ejecutar(AltaEnvioDTO envioDTO, AltaSeguimientoDTO seguimientoDTO);
    }
}