using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IVerDetallesEnvio
    {
        VerDetallesEnvioDTO Ejecutar(int id);
    }
}
