using Compartido.DTOs.UsuarioDTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using Compartido.DTOs.AuditoriaDTO;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUEditarUsuario : IEditarUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUEditarUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public void Ejecutar(EditarUsuarioDTO usuarioDTO, AuditoriaDTO auditoriaDTO)
        {
            Rol rolUsuario = RepoUsuarios.FindById(usuarioDTO.Id).Rol;
            Usuario usuario = UsuarioMapper.UsuarioFromEditarUsuarioDTO(usuarioDTO, rolUsuario);
            usuario.Id = usuarioDTO.Id;
            //RepoUsuarios.Update(usuario);

            Auditoria auditoria = AuditoriaMapper.AuditoriaFromAuditoriaDTO(auditoriaDTO);
            List<Auditoria> auditorias = usuario.Auditorias.ToList();
            auditorias.Add(auditoria);
            usuario.Auditorias = auditorias;
            RepoUsuarios.Update(usuario);
        }
    }
}
