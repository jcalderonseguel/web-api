using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;

namespace Bootstrap.Providers
{
    public static class ValidationConfiguration
    {
        public static IServiceCollection ConfigureValidationsServices(this IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IClientDbContext>());

            // Disable MVC model validations
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddMvc().AddMvcOptions(options =>
            {
                options.ModelMetadataDetailsProviders.Clear();
                options.ModelValidatorProviders.Clear();
            });
            return services;
        }
    }
}
