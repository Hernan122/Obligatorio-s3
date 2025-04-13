using Compartido.DTOs;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.Mappers
{
   public class EnvioMapper
    {
        public static Envio EnvioFromEnvioDTO(EnvioDTO envioDTO)
        {
            if (envioDTO == null)
            {
                throw new ArgumentException("Datos incorrectos");
            }
            return new Envio(envioDTO.NumeroTracking);
        }

    }
}
