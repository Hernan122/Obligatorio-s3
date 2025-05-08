using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioComunCU
{
    public interface IAltaEnvioComun
    {
        void Ejecutar(AltaEnvioComunDTO comunDTO);
    }
}