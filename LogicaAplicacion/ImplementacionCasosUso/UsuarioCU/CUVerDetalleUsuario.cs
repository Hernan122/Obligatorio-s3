using Compartido.DTOs.UsuarioDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUVerDetalleUsuario : IVerDetalleUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUVerDetalleUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

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