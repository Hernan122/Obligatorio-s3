using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class DemoContext : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DemoContext(DbContextOptions options) : base(options)
        {
        }
    }
}