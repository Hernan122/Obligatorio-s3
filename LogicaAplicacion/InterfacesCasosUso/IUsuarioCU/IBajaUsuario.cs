using Compartido.DTOs.AuditoriaDTO;
using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IBajaUsuario
    {
        void Ejecutar (int id, AuditoriaDTO auditoriaDTO);
    }
}