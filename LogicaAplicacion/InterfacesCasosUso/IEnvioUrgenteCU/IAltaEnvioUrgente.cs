using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IComunCU
{
    public interface IAltaEnvioUrgente
    {
        void Ejecutar(AltaComunDTO comunDTO);
    }
}