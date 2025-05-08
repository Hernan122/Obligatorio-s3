using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface ILoginUsuario
    {
        LoginUsuarioDTO Ejecutar (LoginUsuarioDTO usuarioDTO);
    }
}