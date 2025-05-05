using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface IEditarUsuario
    {
        void Ejecutar (EditarUsuarioDTO usuarioDTO);
    }
}