using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvioPorNumeroTracking
    {
        public VerDetallesEnvioYSeguimientosDTO Ejecutar(string numeroTracking);
    }
}