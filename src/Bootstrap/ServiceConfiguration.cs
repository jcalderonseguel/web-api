using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bootstrap.ApplicationBuilder;
using Bootstrap.Providers;

namespace Bootstrap
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMVCServices();
            services.ConfigureSwaggerServices();
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureMediatrServices();
            services.ConfigureValidationsServices();
            services.AddApiVersion();
            services.AddVersionedApiExplorer();
          
            services.AddPerson();

            return services;
        }

        public static IApplicationBuilder Configure(this IApplicationBuilder app, bool isDevelopnment, IApiVersionDescriptionProvider provider)
        {
            app.ConfigureMVC(isDevelopnment);
            app.UseCustomSwagger(provider);

            return app;
        }
    }
}