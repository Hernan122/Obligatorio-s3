using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.ImplementacionCasosUso.EnviosCU
{
    public class AltaEnvio
    {

        public void Ejecutar(EnvioDTO envioDTO)
        {
if (envioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Envio envio = EnvioMapper.EnvioFromEnvioDTO(envioDTO);
        }
    }


}
