using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioComunCU
{
    public interface IBajaEnvioComun
    {
        void Ejecutar(BajaEnvioComunDTO comunDTO);
    }
}