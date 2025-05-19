using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.DTOs.SeguimientoDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUAltaEnvio : IAltaEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        private IRepositorioUsuario RepoUsuario { get; set; }
        private IRepositorioAgencia RepoAgencia { get; set; }

        public CUAltaEnvio(IRepositorioEnvio repoEnvios, IRepositorioUsuario repoUsuario, IRepositorioAgencia repoAgencia)
        {
            RepoEnvios = repoEnvios;
            RepoUsuario = repoUsuario;
            RepoAgencia = repoAgencia;
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

            if (envioDTO is AltaComunDTO)
            {
                AltaComunDTO comunDTO = (AltaComunDTO)envioDTO;
                Comun comun = ComunMapper.ComunFromAltaComunDTO(comunDTO);

                // Encontrar agencia existente
                Agencia agencia = RepoAgencia.FindByName(comunDTO.NombreAgencia);
                if (agencia == null)
                {
                    throw new EnvioException("Agencia inexistente");
                }

                comun.AgenciaId = agencia.Id;
                envio = comun;
                envio.ClienteId = usuario.Id;
                envio.FuncionarioId = envioDTO.FuncionarioId;
            }
            else if (envioDTO is AltaUrgenteDTO)
            {
                AltaUrgenteDTO urgenteDTO = (AltaUrgenteDTO)envioDTO;
                Urgente urgente = UrgenteMapper.UrgenteFromAltaUrgenteDTO(urgenteDTO);

                envio = urgente;
                envio.ClienteId = usuario.Id;
                envio.FuncionarioId = envioDTO.FuncionarioId;
            }

            Seguimiento seguimiento = SeguimientoMapper.SeguimientoFromAltaSeguimientoDTO(seguimientoDTO);
            envio.Seguimientos.Add(seguimiento);

            if (envio is Comun)
            {
                RepoEnvios.Add((Comun)envio);
            }
            else
            {
                RepoEnvios.Add((Urgente)envio);
            }

        }
    }
}