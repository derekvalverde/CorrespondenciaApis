using CapaDatos.Data;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CapaPresentacionJaimito
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApicacionDbContextCorrespondencia>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("ConnectionCorrespondencia")));

            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //JWT Authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);

            services.AddAuthentication(au => {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {

                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Api
            services.AddScoped<IApiUsuarioLoginGeneralService, ApiUsuarioLoginGeneralService>();
            services.AddScoped<IApiLinkSubgrupoService, ApiLinkSubgrupoService>();
            services.AddScoped<IApiClienteVentaCliCodigoService, ApiClienteVentaCliCodigoService>();           
            services.AddScoped<IApiUsuarioReseteoPasswordService, ApiUsuarioReseteoPasswordService>();
            services.AddScoped<IApiCorrespondenciaListarService, ApiCorrespondenciaListarService>();
            services.AddScoped<IApiCorrespondenciaDetalleListarService, ApiCorrespondenciaDetalleListarService>();
            services.AddScoped<IApiCorrespondenciaDetalleBusquedaService, ApiCorrespondenciaDetalleBusquedaService>();
            services.AddScoped<IApiCorrespondenciaListarService, ApiCorrespondenciaListarService>();
            services.AddScoped<IApiCorrespondenciaDetalleInformaciónService, ApiCorrespondenciaDetalleInformacionService>();
            services.AddScoped<IApiCorrespondenciaDetalleInformacionCelularService, ApiCorrespondenciaDetalleInformacionCelularService>();
            services.AddScoped<IApiCorrespondenciaDetalleListarCelularService, ApiCorrespondenciaDetalleListarCelularService>();
            services.AddScoped<IApiCorrespondenciaRegistrarService, ApiCorrespondenciaRegistrarService>();
            services.AddScoped<IApiCorrespondenciaDetalleRegistrarService, ApiCorrespondenciaDetalleRegistrarService>();
            services.AddScoped<IApiCorrespondenciaDetalleDividirService, ApiCorrespondenciaDetalleDividirService>();
            services.AddScoped<IApiCorrespondenciaEliminarService, ApiCorrespondenciaEliminarService>();
            services.AddScoped<IApiArchiveroListarService, ApiArchiveroListarService>();
            services.AddScoped<IApiArchiveroAgregarService, ApiArchiveroAgregarService>();
            services.AddScoped<IApiDescripcionListarService, ApiDescripcionListarService>();
            services.AddScoped<IApiDestinatarioListarService, ApiDestinatarioListarService>();
            services.AddScoped<IApiLectorCelularService, ApiLectorCelularService>();
            services.AddScoped<IApiUsuarioMensajeRegistrarTokenService, ApiUsuarioMensajeRegistrarTokenService>();
            services.AddScoped<IApiAreaDestinoListarService, ApiAreaDestinoListarService>();
            services.AddScoped<IApiCorrespondenciaListarPaginadoService, ApiCorrespondenciaListarPaginadoService>();
            services.AddScoped<IApiCorrespondenciaCantidadRegistrosService, ApiCorrespondenciaCantidadRegistrosService>();
            services.AddScoped<IApiArchiveroCantidadRegistrosService, ApiArchiveroCantidadRegistrosService>();
            services.AddScoped<IApiArchiveroListarPaginadoService, ApiArchiveroListarPaginadoService>();
            services.AddScoped<IApiCorrespondenciaDetalleCantidadRegistrosService, ApiCorrespondenciaDetalleCantidadRegistrosService>();
            services.AddScoped<IApiCorrespondenciaDetalleListarPaginadoService, ApiCorrespondenciaDetalleListarPaginadoService>();
            services.AddScoped<IApiCorrespondenciaBusquedaService, ApiCorrespondenciaBusquedaService>();
           
            
            /************para la obtimizacion de las APIS************/
            services.Configure<GzipCompressionProviderOptions>(options =>
            options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            /********fin obtimizacion de las APIS***********/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseResponseCompression();
            /*************/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
