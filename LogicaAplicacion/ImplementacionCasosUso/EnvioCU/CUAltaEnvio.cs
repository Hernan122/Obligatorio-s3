using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;
using Compartido.DTOs.SeguimientoDTO;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUAltaEnvio : IAltaEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        private IRepositorioUsuario RepoUsuario { get; set; }
        private IRepositorioAgencia RepoAgencia { get; set; }

        public CUAltaEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public void Ejecutar(AltaEnvioDTO envioDTO, AltaSeguimientoDTO seguimientoDTO)
        {

            // Encontrar cliente existente
            Usuario usuario = RepoUsuario.FindByEmail(envioDTO.EmailCliente);
            if (usuario == null)
            {
                throw new EnvioException("Cliente inexistente");
            }
            
            Envio envio = null;

            if (envioDTO is AltaAgenciaDTO)
            {
                Comun comun = (Comun)envio;
                AltaAgenciaDTO comunDTO = (AltaAgenciaDTO)envioDTO;
                comun = ComunMapper.ComunFromAltaComunDTO(comunDTO);

                // Encontrar agencia existente
                Agencia agencia = RepoAgencia.FindByName(comunDTO.NombreAgencia);
                if (agencia == null)
                {
                    throw new EnvioException("Agencia inexistente");
                }

                comun.AgenciaId = agencia.Id;
                envio = comun;
            }
            else
            {
                Urgente urgente = (Urgente)envio;
                AltaUrgenteDTO urgenteDTO = (AltaUrgenteDTO)envioDTO;
                urgente = UrgenteMapper.UrgenteFromAltaUrgenteDTO(urgenteDTO);
                envio = urgente;
            }

            Seguimiento seguimiento = SeguimientoMapper.SeguimientoFromAltaSeguimientoDTO(seguimientoDTO);

            envio.ClienteId = usuario.Id;
            envio.FuncionarioId = envioDTO.FuncionarioId;
            envio.Seguimientos.Add(seguimiento);

            RepoEnvios.Add(envio);
        }
    }
}