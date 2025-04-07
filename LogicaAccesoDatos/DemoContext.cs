using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class DemoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DemoContext(DbContextOptions options) : base(options)
        {
        }
    }
}