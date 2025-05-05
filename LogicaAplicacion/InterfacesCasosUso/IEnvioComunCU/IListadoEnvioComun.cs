using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IComunCU
{
    public interface IListadoEnvioComun
    {
        void Ejecutar(ListadoEnvioComunDTO comunDTO);
    }
}