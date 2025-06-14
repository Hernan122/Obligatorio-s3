using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IListadoEnviosDetallados
    {
        List<VerDetallesEnvioYSeguimientosDTO> Ejecutar(int clienteId);
    }
}
