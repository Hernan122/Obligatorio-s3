using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface IListadoUsuario
    {
        List<VerUsuarioDTO> Ejecutar ();
    }
}