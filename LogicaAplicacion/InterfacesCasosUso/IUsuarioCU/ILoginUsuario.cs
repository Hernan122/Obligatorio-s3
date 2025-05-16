using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface ILoginUsuario
    {
        InformacionUsuarioLogueadoViewModelDTO Ejecutar (LoginUsuarioDTO usuarioDTO);
    }
}