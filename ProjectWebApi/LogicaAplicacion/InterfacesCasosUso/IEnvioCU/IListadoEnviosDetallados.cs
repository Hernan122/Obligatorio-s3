using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IListadoEnviosDetallados
    {
        List<ListadoEnviosDetalladosDTO> Ejecutar(int clienteId);
    }
}
