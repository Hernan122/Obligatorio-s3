using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioComunCU
{
    public interface IListadoEnvioComun
    {
        void Ejecutar(ListadoEnvioComunDTO comunDTO);
    }
}