using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvio
    {
        VerDetallesEnvioDTO Ejecutar(int id);
    }
}