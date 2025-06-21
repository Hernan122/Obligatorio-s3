using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvioPorNumeroTracking
    {
        public ListadoEnviosDetalladosDTO Ejecutar(string numeroTracking);
    }
}