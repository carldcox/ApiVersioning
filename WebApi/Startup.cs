using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Add in Microsoft's Api Versioning library and configure some defaults 
            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);//Default Api Version
                setup.AssumeDefaultVersionWhenUnspecified = true;//Make any unversioned call use the default
                setup.ReportApiVersions = true;//Adds api-supported-versions header to all responses
                
                /*Change how we get the api version*/
                //Default is url segment so this line is redundant
                setup.ApiVersionReader = new UrlSegmentApiVersionReader();
                
                //Query Parameter, default parm name is api-version, here we are changing that to v
                setup.ApiVersionReader = new QueryStringApiVersionReader("v");
                
                //Header
                setup.ApiVersionReader = new HeaderApiVersionReader("api-version");
                
                //ContentType
                // Content-type: application/json;v=1.0 --default
                // Customized to Content-Type: application/json;version=1.0
                setup.ApiVersionReader = new MediaTypeApiVersionReader("version");
            });
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}