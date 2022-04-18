using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreAvaliacao.Application.Interfaces;
using NetCoreAvaliacao.Application.Services;
using NetCoreAvaliacao.Domain.Interfaces;
using NetCoreAvaliacao.Infra.Data.Context;
using NetCoreAvaliacao.Infra.Data.Repositories;

namespace NetCoreAvaliacao.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddTransient<AppDbContext>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
