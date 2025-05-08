using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IListadoEnvio
    {
        List<ListadoEnvioDTO> Ejecutar();
    }
}
