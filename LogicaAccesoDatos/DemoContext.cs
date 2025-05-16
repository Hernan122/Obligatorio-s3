using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class DemoContext : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DemoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Envio>()
            //    .HasOne(e => e.Cliente)
            //    .WithMany()
            //    .HasForeignKey(e => e.ClienteId)
            //    .OnDelete(DeleteBehavior.NoAction); // Evita la eliminación en cascada

            //modelBuilder.Entity<Envio>()
            //    .HasOne(e => e.Funcionario)
            //    .WithMany()
            //    .HasForeignKey(e => e.FuncionarioId)
            //    .OnDelete(DeleteBehavior.NoAction); // Evita la eliminación en cascada

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nombre)
                .HasConversion(
                    nombre => nombre.Valor,
                    valor => new NombreUsuario(valor) // Convierte ValueObject en string
                );

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasConversion(
                    email => email.Valor,
                    valor => new EmailUsuario(valor) // Convierte ValueObject en string
                );

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Seguimiento)
                .WithOne(s => s.Envio)
                .HasForeignKey<Envio>(e => e.SeguimientoId)
                .OnDelete(DeleteBehavior.NoAction); // Evita la eliminación en cascada

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithOne()
                .HasForeignKey<Envio>(e => e.ClienteId)
                .OnDelete(DeleteBehavior.NoAction); // Evita la eliminación en cascada

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Funcionario)
                .WithOne()
                .HasForeignKey<Envio>(e => e.FuncionarioId)
                .OnDelete(DeleteBehavior.NoAction); // Evita la eliminación en cascada
            
            modelBuilder.Entity<Comun>()
                .HasOne(e => e.Agencia)
                .WithOne()
                .HasForeignKey<Comun>(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Seguimiento>()
                .HasOne(e => e.Envio)
                .WithOne(s => s.Seguimiento)
                .HasForeignKey<Seguimiento>(e => e.FuncionarioId) // Evita la eliminación en cascada
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}