using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monitoramento.Api.Hubs;
using Monitoramento.Dominio.Entidades;
using Monitoramento.Dominio.Interfaces;
using Monitoramento.Infra.AMQP;
using Monitoramento.Infra.Servicos;

namespace Monitoramento.Api
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
            services.Configure<Limites>(options => Configuration.GetSection("Limites").Bind(options));

            services.AddSingleton<IConexaoFila>(provider => new ConexaoFila(Configuration["RabbitMQ:Host"], Configuration["RabbitMQ:Fila"]));
            services.AddSingleton<ISensores, MockSensores>();
            services.AddSingleton<IServicoDefesaCivil, MockServicoDefesaCivil>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSignalR();
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

            app.UseSignalR(routes =>
            {
                routes.MapHub<SensoresHub>("/hubs/sensores");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
