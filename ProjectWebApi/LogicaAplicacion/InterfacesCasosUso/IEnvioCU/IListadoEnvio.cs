using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IListadoEnvio
    {
        List<ListadoEnvioDTO> Ejecutar();
    }
}
