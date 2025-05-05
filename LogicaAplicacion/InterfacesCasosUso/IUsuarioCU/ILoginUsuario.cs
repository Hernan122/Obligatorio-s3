using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface ILoginUsuario
    {
        LoginUsuarioDTO Ejecutar (LoginUsuarioDTO usuarioDTO);
    }
}