using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KraftHeinz.Models;
using KraftHeinz.Services;
using KraftHeinz.Data;
using Swashbuckle;
using Microsoft.OpenApi.Models;
using Oracle.ManagedDataAccess.Client;
using Microsoft.EntityFrameworkCore;


namespace KraftHeinz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do banco de dados
            services.AddDbContext<OracleDbContext>(options =>
                options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

            // Configuração dos serviços
            services.AddScoped<IFactoryService, FactoryService>();
            //services.AddScoped<IReservoirService, ReservoirService>();
            //services.AddScoped<IPowerPlantService, PowerPlantService>();

            // Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KraftHeinz API", Version = "v1" });
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KraftHeinz API v1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}