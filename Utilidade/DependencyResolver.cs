using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Infra.Persistencias.Repositorios;
using Infra.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Zicard.API.Common.Persistencia.Cache;

namespace Utilidade
{
    public static class DependencyResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            var config = new AutoMapperConfiguration().Configure().CreateMapper();
            services.AddSingleton(config);


            IncludeRepositorios(services);
            IncludeServico(services);
        }
        private static void IncludeRepositorios(IServiceCollection services)
        {
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioEndereco, RepositorioEndereco>();
            services.AddScoped<IRepositorioPedido, RepositorioPedido>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
        }

        private static void IncludeServico(IServiceCollection services)
        {
            services.AddScoped<IServicoCategoria, ServicoCategoria>();
            services.AddScoped<IServicoEndereco, ServicoEndereco>();
            services.AddScoped<IServicoPedido, ServicoPedido>();
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
        }
    }
}