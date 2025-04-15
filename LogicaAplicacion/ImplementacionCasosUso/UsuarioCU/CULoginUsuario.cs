using Compartido.DTOs.UsuarioDTO;
using Compartido.DTOs.UsuarioDTO.CRUD;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject.Usuario;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CULoginUsuario
    {
        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();
        public void Ejecutar(LoginUsuarioDTO usuarioDTO)
        {
            Usuario usuario = UsuarioMapper.UsuarioFromLoginUsuarioDTO(usuarioDTO);
            if (RepoUsuarios.FindByEmailAndPassword(usuario) == null)
            {
                throw new Exception("Usuario inexistente, o credenciales incorrectas");
            }
        }
    }
}