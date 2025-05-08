using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IListadoUsuario
    {
        List<ListadoEnvioDTO> Ejecutar ();
    }
}