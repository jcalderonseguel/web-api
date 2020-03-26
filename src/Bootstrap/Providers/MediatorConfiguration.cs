using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Mediators.PersonOperations.GetById;

namespace Bootstrap.Providers
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetByIdHandler).Assembly);
            return services;
        }
    }
}