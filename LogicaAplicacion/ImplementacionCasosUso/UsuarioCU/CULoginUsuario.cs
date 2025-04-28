using Compartido.DTOs.UsuarioDTO;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CULoginUsuario : ILoginUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CULoginUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public LoginUsuarioDTO Ejecutar(LoginUsuarioDTO usuarioDTO)
        {
            Usuario usuario = UsuarioMapper.UsuarioFromLoginUsuarioDTO(usuarioDTO);
            Usuario usuarioEncontrado = RepoUsuarios.FindByEmailAndPassword(usuario);

            if (usuarioEncontrado == null)
            {
                throw new Exception("Usuario inexistente o credenciales incorrectas");
            }

            // Devolvés los datos que necesitás (por ejemplo, el rol)
            return new LoginUsuarioDTO()
            {
                Email = usuarioEncontrado.Email.Valor,
                Rol = usuarioEncontrado.Rol.ToString()
            };
        }
    }
}