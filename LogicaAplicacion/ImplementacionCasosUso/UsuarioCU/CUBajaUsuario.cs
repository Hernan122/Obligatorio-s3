using LogicaAccesoDatos.Repositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class CUBajaUsuario
    {
        private RepositorioUsuario RepoUsuarios = new RepositorioUsuario();
        public void Ejecutar(int id)
        {
            RepoUsuarios.Delete(id);
        }
    }
}