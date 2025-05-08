using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioComunCU
{
    public interface IVerDetalleEnvioComun
    {
        void Ejecutar(VerDetalleEnvioComunDTO comunDTO);
    }
}