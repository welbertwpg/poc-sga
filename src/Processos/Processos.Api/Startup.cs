using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;
using Processos.Dominio.Validacoes;
using Processos.Infra.Contexto;
using Processos.Infra.Repositorios;

namespace Processos.Api
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
            services.AddDbContext<DbContext, ContextoProcessos>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                o => o.MigrationsAssembly("Processos.Infra")));

            services.AddScoped<IRepositorioProcessos, RepositorioProcessos>();
            services.AddScoped<IRepositorioProblemas, RepositorioProblemas>();
            services.AddScoped<IRepositorioParadas, RepositorioParadas>();

            services.AddSingleton<IValidator<Processo>, ValidadorProcesso>();
            services.AddSingleton<IValidator<Etapa>, ValidadorEtapa>();
            services.AddSingleton<IValidator<Problema>, ValidadorProblema>();
            services.AddSingleton<IValidator<Parada>, ValidadorParada>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
