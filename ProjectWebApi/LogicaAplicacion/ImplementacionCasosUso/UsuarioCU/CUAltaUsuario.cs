using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Compartido.DTOs.UsuarioDTO;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.DTOs.AuditoriaDTO;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUAltaUsuario : IAltaUsuario
    {

        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public void Ejecutar(AltaUsuarioDTO usuarioDTO, AuditoriaDTO auditoriaDTO)
        {
            Usuario usuario = UsuarioMapper.UsuarioFromAltaUsuarioDTO(usuarioDTO);

            // Agregamos auditoria
            Auditoria auditoria = AuditoriaMapper.AuditoriaFromAuditoriaDTO(auditoriaDTO);
            List<Auditoria> auditorias = usuario.Auditorias.ToList();
            auditorias.Add(auditoria);
            usuario.Auditorias = auditorias;
            RepoUsuarios.Add(usuario);
        }
    }
}