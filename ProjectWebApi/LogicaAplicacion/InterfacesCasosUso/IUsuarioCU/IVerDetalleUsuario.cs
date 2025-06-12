using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IUsuarioCU
{
    public interface IVerDetalleUsuario
    {
        VerDetallesUsuarioDTO Ejecutar (int id);
    }
}