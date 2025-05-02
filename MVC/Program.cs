using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using LogicaAccesoDatos.Repositorios.RepoUsuario;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar servicios al contenedor
            builder.Services.AddControllersWithViews();

            // Inversión de control
            builder.Services.AddScoped<IRepositorioAgencia,     RepositorioAgenciaEF>();
            builder.Services.AddScoped<IRepositorioComun,       RepositorioComunEF>();
            builder.Services.AddScoped<IRepositorioEnvio,       RepositorioEnvioEF>();
            builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimientoEF>();
            builder.Services.AddScoped<IRepositorioUbicacion,   RepositorioUbicacionEF>();
            builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimientoEF>();
            builder.Services.AddScoped<IRepositorioUrgente,     RepositorioUrgenteEF>();
            builder.Services.AddScoped<IRepositorioUsuario,     RepositorioUsuario>();

            // Configuraci�n de la cadena de conexi�n a la base de datos
            string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
            builder.Services.AddDbContext<DemoContext>(option => option.UseSqlServer(cadenaConexion));

            // Agregar soporte para la sesi�n
            builder.Services.AddDistributedMemoryCache(); // Usamos memoria distribuida para la sesi�n
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Configura el tiempo de inactividad de la sesi�n
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Marca la cookie como esencial para la aplicaci�n
            });

            var app = builder.Build();

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Habilitar la sesi�n
            app.UseSession();

            app.UseAuthorization();  // Authorization debe ir despu�s de UseSession

            // Configuraci�n de la ruta predeterminada
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}