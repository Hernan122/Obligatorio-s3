using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IAltaEnvio
    {
        void Ejecutar(AltaEnvioDTO usuarioDTO, int tipoEnvio);
    }
}