using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.IEnvioCU;
using LogicaAplicacion.InterfacesCasosUso.IUsuarioCU;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            builder.Services.AddScoped<IVerDetalleUsuario, CUVerDetalleUsuario>();

            // RF2
            builder.Services.AddScoped<ILoginUsuario, CULoginUsuario>();

            // RF3
            builder.Services.AddScoped<ICambiarPassword, CUCambiarPassword>();

            string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
            builder.Services.AddDbContext<DemoContext>
                (option => option.UseSqlServer(cadenaConexion));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ---------------------------------- JWT ----------------------------------
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut => 
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut => {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            // ---------------------------------- JWT ----------------------------------
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