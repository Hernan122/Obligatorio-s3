using Compartido.DTOs.ComunDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IAltaEnvioUrgente
{
    public interface IListadoEnvioUrgente
    {
        void Ejecutar(ListadoComunDTO comunDTO);
    }
}