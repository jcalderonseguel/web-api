using Microsoft.Extensions.DependencyInjection;
using Domain.Repositories;
using Persistance.Commands;
using Persistance.Queries;

namespace Bootstrap.Providers
{
    public static class PersonConfiguration
    {
        public static IServiceCollection AddPerson(this IServiceCollection services)
        {
            services.AddTransient<IPersonQuery, PersonQuery>();
            services.AddTransient<IPersonDataRepository, PersonDataRepository>();

            return services;
        }
    }
}