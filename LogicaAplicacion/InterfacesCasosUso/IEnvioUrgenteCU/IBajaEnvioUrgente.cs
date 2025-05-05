using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IComunCU
{
    public interface IBajaEnvioUrgente
    {
        void Ejecutar(BajaComunDTO comunDTO);
    }
}
