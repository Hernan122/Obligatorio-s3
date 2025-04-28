using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioComun, RepositorioComun>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimiento>();
            builder.Services.AddScoped<IRepositorioUbicacion, RepositorioUbicacion>();
            builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimiento>();
            builder.Services.AddScoped<IRepositorioUrgente, RepositorioUrgente>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

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