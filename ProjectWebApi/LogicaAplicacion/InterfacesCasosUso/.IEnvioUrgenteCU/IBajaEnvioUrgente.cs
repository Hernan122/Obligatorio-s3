using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IAltaEnvioUrgente
{
    public interface IBajaEnvioUrgente
    {
        void Ejecutar(BajaComunDTO comunDTO);
    }
}
