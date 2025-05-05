using Compartido.DTOs.UsuarioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface IVerDetalleUsuario
    {
        VerDetallesUsuarioDTO Ejecutar (int id);
    }
}