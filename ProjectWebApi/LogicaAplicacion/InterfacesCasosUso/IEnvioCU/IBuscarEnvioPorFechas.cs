using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvioPorFechas
    {
        public List<ListadoEnviosInfoRelevanteDTO> Ejecutar(int estado, BuscarEnvioPorFechasDTO envio);
    }
}