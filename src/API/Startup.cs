using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Presenters;
using API.Presenters.Interfaces;
using Bootstrap;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices(Configuration);

            //services.AddTransient<IAccountPresenter, AccountPresenter>();
            services.AddTransient<IBasePresenter, BasePresenter>();
            services.AddTransient<IPersonPresenter, PersonPresenter>();
            services.AddTransient<IDocumentTypePresenter, DocumentTypePresenter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.Configure(env.IsDevelopment(), provider);
        }
    }
}