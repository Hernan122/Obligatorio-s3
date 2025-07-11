﻿using Compartido.DTOs.EnvioDTO;
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

            Envio envio;

            if (envioDTO is AltaComunDTO)
            {
                AltaComunDTO comunDTO = (AltaComunDTO)envioDTO;

                // Encontrar agencia existente
                Agencia agencia = RepoAgencia.FindByName(comunDTO.NombreAgencia);
                if (agencia == null)
                {
                    throw new EnvioException("Agencia inexistente");
                }
                
                envio = ComunMapper.ComunFromAltaComunDTO(comunDTO, usuario.Id, agencia.Id);
            }
            else
            {
                envio = UrgenteMapper.UrgenteFromAltaUrgenteDTO((AltaUrgenteDTO)envioDTO, usuario.Id);
            }

            RepoEnvios.Add(envio);

            // Agregamos Seguimiento
            Seguimiento seguimiento = SeguimientoMapper.SeguimientoFromAltaSeguimientoDTO(seguimientoDTO);
            List<Seguimiento> seguimientos = envio.Seguimientos.ToList();
            seguimientos.Add(seguimiento);
            envio.Seguimientos = seguimientos;
            RepoEnvios.Update(envio);
        }
    }
}