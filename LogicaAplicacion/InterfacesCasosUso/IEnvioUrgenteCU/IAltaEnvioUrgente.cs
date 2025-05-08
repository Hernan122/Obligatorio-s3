using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioUrgente
{
    public interface IAltaEnvioUrgente
    {
        void Ejecutar(AltaComunDTO comunDTO);
    }
}