using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Models;
using Ativos.Dominio.Validations;
using Ativos.Infra.Repositories;
using Ativos.Infra.Services;
using CrossCutting.Exceptions.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Serilog;

namespace AtivosApi
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
            services.AddScoped<IMongoClient>(provider => new MongoClient(Configuration.GetConnectionString("MongoDB")));
            services.AddScoped<IRepositorioAtivos, RepositorioAtivosMongoDB>();
            services.AddScoped<IRepositorioManutencoes, RepositorioAtivosMongoDB>();
            services.AddScoped<IRepositorioCronogramas, RepositorioCronogramasMongoDB>();

            services.AddSingleton<IValidator<Ativo>, ValidadorAtivo>();
            services.AddSingleton<IValidator<Manutencao>, ValidadorManutencao>();
            services.AddSingleton<IValidator<CronogramaManutencao>, ValidadorCronograma>();

            services.AddScoped<IServicoAquisicoes, MockServicoAquisicoes>();

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            services.AddSingleton<ILogger>(logger);

            services.AddMvc(setup => setup.Filters.Add(new FiltroExcecaoValidacao(logger))).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
