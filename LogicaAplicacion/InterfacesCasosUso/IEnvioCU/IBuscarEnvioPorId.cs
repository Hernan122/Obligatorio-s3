using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvioPorId
    {
        public VerDetallesEnvioDTO Ejecutar(int id);
    }
}