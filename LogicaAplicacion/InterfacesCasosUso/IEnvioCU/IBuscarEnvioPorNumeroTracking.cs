using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvioPorNumeroTracking
    {
        public VerDetallesEnvioDTO Ejecutar(string numeroTracking);
    }
}