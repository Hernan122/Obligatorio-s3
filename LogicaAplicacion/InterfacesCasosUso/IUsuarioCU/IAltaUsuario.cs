using Compartido.DTOs.AuditoriaDTO;
using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IAltaUsuario
    {
        void Ejecutar (AltaUsuarioDTO p1, AuditoriaDTO p2);
    }
}