using Compartido.DTOs.EnvioDTO;

namespace LogicaAplicacion.InterfacesCasosUso.IEnvioCU
{
    public interface IBuscarEnvioPorComentario
    {
        public List<ListadoEnviosDTO> Ejecutar(string comentario);
    }
}