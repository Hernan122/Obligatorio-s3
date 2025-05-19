using Compartido.DTOs.AgenciaDTO;
using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
    public class CUListadoAgencia : IListadoAgencia
    {
        private IRepositorioAgencia RepoAgencias { get; set; }

        public CUListadoAgencia(IRepositorioAgencia repoAgencia)
        {
            RepoAgencias = repoAgencia;
        }

        public List<ListadoAgenciaDTO> Ejecutar()
        {
            List<ListadoAgenciaDTO> agenciasDTO = new List<ListadoAgenciaDTO>();
            List<Agencia> agencias = RepoAgencias.FindAll().ToList();
            agenciasDTO = AgenciaMapper.ListadoAgenciaToListadoAgenciaDTO(agencias);
            return agenciasDTO;
        }
    }
}