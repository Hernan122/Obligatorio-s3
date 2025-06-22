using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface ILoginUsuario
    {
        InformacionUsuarioLogueadoDTO Ejecutar (LoginUsuarioDTO usuarioDTO);
    }
}