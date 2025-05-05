using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IComunCU
{
    public interface IListadoEnvioUrgente
    {
        void Ejecutar(ListadoComunDTO comunDTO);
    }
}