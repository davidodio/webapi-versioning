using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TapEnd.VersioningExample
{    
    public class Startup
    {
        readonly ApiVersion apiVersion = new ApiVersion(1, 0);
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(opts => {
                opts.ReportApiVersions = true;
                opts.Conventions.Add(new VersionByNamespaceConvention());
                opts.ApiVersionReader = new MediaTypeApiVersionReader();
            
                opts.AssumeDefaultVersionWhenUnspecified = true;
                opts.DefaultApiVersion = apiVersion;
            });

            services.AddVersionedApiExplorer(opts => {
                opts.GroupNameFormat = "'v'VVV";
            });

            services
                .AddOpenApiDocument(doc => {
                    doc.ApiGroupNames = new[] { "1" };
                    doc.DocumentName = "v1";
                    doc.Title = $"Versioning Example - v1";
                    doc.Version = "v1";
                })

                .AddOpenApiDocument(doc => {
                    doc.ApiGroupNames = new[] { "2" };
                    doc.DocumentName = "v2";
                    doc.Title = $"Versioning Example - v2";
                    doc.Version = "v2";
                });                      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3(opts => {

            });
            // app.UseReDoc();            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
