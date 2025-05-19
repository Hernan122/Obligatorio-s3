using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IEditarEnvio
    {
        void Ejecutar(EditarEnvioDTO envioDTO);
    }
}