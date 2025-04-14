using Compartido.DTOs.UsuarioDTO.CRUD;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface IAltaUsuario
    {
        void Ejecutar (AltaUsuarioDTO usuarioDTO);
    }
}