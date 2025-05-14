using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IAltaUsuario
    {
        void Ejecutar (AltaUsuarioDTO usuarioDTO);
    }
}