using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IComunCU
{
    public interface IBajaEnvioComun
    {
        void Ejecutar(BajaEnvioComunDTO comunDTO);
    }
}