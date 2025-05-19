using Compartido.DTOs.AgenciaDTO;
using Compartido.DTOs.EnvioDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
    public class CUAltaAgencia : IAltaAgencia
    {
        private IRepositorioAgencia RepoAgencias { get; set; }

        public CUAltaAgencia(IRepositorioAgencia repoAgencia)
        {
            RepoAgencias = repoAgencia;
        }

        public void Ejecutar(AltaAgenciaDTO agenciaDTO)
        {
            Agencia agencia = AgenciaMapper.AgenciaFromAltaAgenciaDTO(agenciaDTO);
            Agencia buscarAgencia = RepoAgencias.FindByName(agencia.Nombre);

            if (buscarAgencia == null)
            {
                RepoAgencias.Add(agencia);
            }
            else
            {
                throw new UsuarioException("Ya existe esa Agencia");
            }
        }

    }
}