using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;

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
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgenciaEF>();
            builder.Services.AddScoped<IAltaAgencia, CUAltaAgencia>();
            builder.Services.AddScoped<IListadoAgencia, CUListadoAgencia>();

            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvioEF>();
            builder.Services.AddScoped<IAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<IBajaEnvio, CUBajaEnvio>();
            builder.Services.AddScoped<IListadoEnvio, CUListadoEnvio>();
            builder.Services.AddScoped<ICambiarEstadoEnvio, CUCambiarEstadoEnvio>();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<IBajaUsuario, CUBajaUsuario>();
            builder.Services.AddScoped<IEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<IListadoUsuario, CUListadoUsuario>();
            builder.Services.AddScoped<ILoginUsuario, CULoginUsuario>();
            builder.Services.AddScoped<IVerDetalleUsuario, CUVerDetalleUsuario>();

            // Configuraci?n de la cadena de conexi?n a la base de datos
            string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
            builder.Services.AddDbContext<DemoContext>(option => option.UseSqlServer(cadenaConexion));

            // Agregar soporte para la sesi?n
            builder.Services.AddDistributedMemoryCache(); // Usamos memoria distribuida para la sesi?n
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Configura el tiempo de inactividad de la sesi?n
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Marca la cookie como esencial para la aplicaci?n
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

            // Habilitar la sesi?n
            app.UseSession();

            app.UseAuthorization();  // Authorization debe ir despu?s de UseSession

            // Configuraci?n de la ruta predeterminada
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Login}/{id?}");

            app.Run();
        }
    }
}