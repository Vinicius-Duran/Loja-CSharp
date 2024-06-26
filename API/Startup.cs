﻿using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Infra.Persistencias;
using Infra.Persistencias.Repositorios;
using Infra.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API
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
            // Configuração do DbContext
            services.AddDbContext<APIContexto>(options => {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly("Infra"));
            });



            // Outros serviços
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Financeiro", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioEndereco, RepositorioEndereco>();
            services.AddScoped<IRepositorioPedido, RepositorioPedido>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            services.AddCors();
            
            services.AddScoped<IServicoCategoria, ServicoCategoria>();
            services.AddScoped<IServicoEndereco, ServicoEndereco>();
            services.AddScoped<IServicoPedido, ServicoPedido>();
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuração do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NomeDaSuaAPI v1");
            });

            // Outras configurações de middleware
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
