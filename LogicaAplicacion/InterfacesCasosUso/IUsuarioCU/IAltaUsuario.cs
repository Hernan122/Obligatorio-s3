using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface IAltaUsuario
    {
        void Ejecutar (AltaUsuarioDTO usuarioDTO);
    }
}