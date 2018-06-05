using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Nextekk.MomPop.Core.Services;
using Nextekk.MomPop.Business;

namespace Nextekk.MomPop.Web
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
            services.AddMvc();

            services.AddTransient<IProductService, ProductService>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Info
                {
                    Title = "Nextekk Mom Pop",
                    Description = " This is web application for selling computers",
                    TermsOfService = string.Empty,
                    Contact = new Contact
                    {
                        Name = "NexTekk LLC",
                        Email = string.Empty,
                        Url = string.Empty
                    }
                });

                var basePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "NexTekk.MomPop.Web.xml");

                opt.IncludeXmlComments(string.Format(basePath));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "NexTekk Mom Pop");
            });

            app.UseMvc();

        }
    }
}
