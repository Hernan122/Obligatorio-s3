using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IComunCU
{
    public interface IAltaEnvioComun
    {
        void Ejecutar(AltaEnvioComunDTO comunDTO);
    }
}