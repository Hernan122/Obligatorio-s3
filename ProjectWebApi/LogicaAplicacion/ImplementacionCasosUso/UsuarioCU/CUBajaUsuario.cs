using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using Compartido.DTOs.AuditoriaDTO;
using Compartido.Mappers;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUBajaUsuario : IBajaUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public CUBajaUsuario(IRepositorioUsuario repoUsuarios) 
        {
            RepoUsuarios = repoUsuarios;
        }

        public void Ejecutar(int id, AuditoriaDTO auditoriaDTO)
        {
            Usuario usuario = RepoUsuarios.FindById(id);

            // Agregamos auditoria
            Auditoria auditoria = AuditoriaMapper.AuditoriaFromAuditoriaDTO(auditoriaDTO);
            List<Auditoria> auditorias = usuario.Auditorias.ToList();
            auditorias.Add(auditoria);
            usuario.Auditorias = auditorias;
            RepoUsuarios.Update(usuario);
        }
    }
}