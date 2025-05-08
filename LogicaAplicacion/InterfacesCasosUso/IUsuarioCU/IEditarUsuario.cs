using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IEditarUsuario
    {
        void Ejecutar (EditarUsuarioDTO usuarioDTO);
    }
}