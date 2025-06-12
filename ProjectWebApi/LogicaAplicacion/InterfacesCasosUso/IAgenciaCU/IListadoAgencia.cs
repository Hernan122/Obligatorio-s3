using Compartido.DTOs.AgenciaDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IListadoAgencia
    {
        List<ListadoAgenciaDTO> Ejecutar();
    }
}