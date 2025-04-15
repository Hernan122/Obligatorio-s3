using Compartido.DTOs.UsuarioDTO.CRUD;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUVerDetalleUsuario
    {
        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();

        public VerDetallesUsuarioDTO Ejecutar(int id)
        {
            Usuario usuario = RepoUsuarios.FindById(id);
            if (usuario == null)
            {
                throw new UsuarioException("Usuario no existente");
            }
            return new VerDetallesUsuarioDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.Nombre.Valor,
                Email = usuario.Email.Valor,
                Password = usuario.Password.Valor,
                Rol = usuario.Rol
            };
        }
    }
}