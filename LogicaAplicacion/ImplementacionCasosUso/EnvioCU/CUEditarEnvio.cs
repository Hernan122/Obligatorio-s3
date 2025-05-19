using Compartido.DTOs.EnvioDTO;
using Compartido.DTOs.EnvioDTO.ComunDTO;
using Compartido.DTOs.EnvioDTO.UrgenteDTO;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using Compartido.Mappers;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class CUEditarEnvio : IEditarEnvio
    {
        private IRepositorioEnvio RepoEnvios { get; set; }

        public CUEditarEnvio(IRepositorioEnvio repoEnvios)
        {
            RepoEnvios = repoEnvios;
        }

        public void Ejecutar(EditarEnvioDTO envioDTO)
        {
            Envio envio = RepoEnvios.FindById(envioDTO.Id);

            if (envio == null)
            {
                throw new ArgumentNullException("Objeto null");
            }

            Envio nuevoEnvio = null;  

            if (envio is Comun)
            {
                nuevoEnvio = ComunMapper.ComunFromEditarComunDTO((EditarComunDTO)envioDTO);
            }
            else
            {
                nuevoEnvio = UrgenteMapper.UrgenteFromEditarUrgenteDTO((EditarUrgenteDTO)envioDTO);
            }

            RepoEnvios.Update(nuevoEnvio);
        }
    }
}