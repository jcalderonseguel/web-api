using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using Application.Common.Interfaces;
using Domain.Repositories;
using Persistance;
using System.Data;
using System.Data.SqlClient;

namespace Bootstrap.Providers
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration, bool addHealthCheck = true)
        {
            var connectionString = configuration.GetConnectionString("PersonsDB");

            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddDbContextPool<ClientDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Persistance")));
            services.AddScoped<IUnitOfWork, ClientDbContextUnitOfWork>();

            services.AddScoped<IClientDbContext>(provider => provider.GetService<ClientDbContext>());

            return services;
        }
    }
}