using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Core.ApplicationServiceImple;
using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;

namespace PetShop.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepostiory>();
            serviceCollection.AddScoped<IPetTypeRerpository, PetTypeRepostiory>();

            serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                Title = "Swagger demo API", 
                Description = "Demo API for Showing swagger",
                Version = "v1"
                
                });
            });

            serviceCollection.AddControllers().AddNewtonsoftJson(o => {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.SerializerSettings.MaxDepth = 5;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           // if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                   var petRepo =  scope.ServiceProvider.GetRequiredService<IPetRepository>();
                   var ownerRepo =  scope.ServiceProvider.GetRequiredService<IOwnerRepository>();
                   var petTypeRepo = scope.ServiceProvider.GetRequiredService<IPetTypeRerpository>(); 

                    var mockDa = new MockData(petRepo, ownerRepo, petTypeRepo);
                    mockDa.InitData();
                }

           
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
           
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
            }
            );
            

            
        }
    }
}
