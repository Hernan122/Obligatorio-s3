using Compartido.DTOs.SeguimientoDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IListadoSeguimientos
    {
        List<ListadoSeguimientosDTO> Ejecutar(int envioId);
    }
}