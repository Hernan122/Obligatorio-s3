using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUVerDetallesEnvio : IVerDetallesEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }
        private IRepositorioAgencia RepoAgencias { get; set; }

        public CUVerDetallesEnvio(IRepositorioEnvio repoEnvios, IRepositorioAgencia repoAgencias)
        {
            RepoEnvios = repoEnvios;
            RepoAgencias = repoAgencias;
        }
        public VerDetallesEnvioDTO Ejecutar(int id)
        {
            Envio envio = RepoEnvios.FindById(id);
            if (envio == null)
            {
                throw new ArgumentNullException("Objeto null");
            }

            VerDetallesEnvioDTO envioDTO = null;

            if (envio is Comun)
            {
                VerDetallesComunDTO comunDTO = EnvioMapper.ComunToComunDTO((Comun)envio);
                Comun comun = (Comun)envio;
                Agencia agencia = RepoAgencias.FindById(comun.AgenciaId);

                comunDTO.NombreAgencia = agencia.Nombre;
                envioDTO = comunDTO;
            }
            else
            {
                VerDetallesUrgenteDTO urgenteDTO = EnvioMapper.UrgenteToUrgenteDTO((Urgente)envio);
                envioDTO = urgenteDTO;
            }

            return envioDTO;
        }
    }
}