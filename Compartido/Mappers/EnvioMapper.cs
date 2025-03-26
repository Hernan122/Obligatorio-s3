using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
