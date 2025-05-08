using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IAltaUsuario
    {
        void Ejecutar (AltaEnvioDTO usuarioDTO);
    }
}