using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgenciaEF>();
            builder.Services.AddScoped<IAltaAgencia, CUAltaAgencia>();
            builder.Services.AddScoped<IListadoAgencia, CUListadoAgencia>();

            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvioEF>();
            builder.Services.AddScoped<IAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<IBajaEnvio, CUBajaEnvio>();
            builder.Services.AddScoped<IListadoEnvio, CUListadoEnvios>();
            builder.Services.AddScoped<ICambiarEstadoEnvio, CUCambiarEstadoEnvio>();
            builder.Services.AddScoped<IBuscarEnvioPorId, CUBuscarEnvioPorId>();

            // RF1
            builder.Services.AddScoped<IBuscarEnvioPorNumeroTracking, CUBuscarEnvioPorNumeroTracking>();

            // RF4
            builder.Services.AddScoped<IListadoEnviosDetallados, CUListadoEnviosDetallados>();
            builder.Services.AddScoped<IListadoSeguimientos, CUListadoSeguimientos>();

            // RF5
            builder.Services.AddScoped<IBuscarEnvioPorFechas, CUBuscarEnvioPorFechas>();

            // RF6
            builder.Services.AddScoped<IBuscarEnvioPorComentario, CUBuscarEnvioPorComentario>();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<IBajaUsuario, CUBajaUsuario>();
            builder.Services.AddScoped<IEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<IListadoUsuario, CUListadoUsuario>();
            builder.Services.AddScoped<ILoginUsuario, CULoginUsuario>();
            builder.Services.AddScoped<IVerDetalleUsuario, CUVerDetalleUsuario>();
            builder.Services.AddScoped<ICambiarPassword, CUCambiarPassword>();

            string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
            builder.Services.AddDbContext<DemoContext>(option => option.UseSqlServer(cadenaConexion));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(opt => opt.IncludeXmlComments("WebAPI.xml"));
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}