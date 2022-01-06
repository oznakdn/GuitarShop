using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GuitarShop.WebApi.Business.Abstract;
using GuitarShop.WebApi.Business.Concrete;
using GuitarShop.WebApi.DataAccess.Abstract;
using GuitarShop.WebApi.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GuitarShop.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GuitarShop.WebApi", Version = "v1" });
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IGuitarService,GuitarManager>();
            services.AddScoped<IGuitarRepo,GuitarRepo>();

            services.AddScoped<IBrandService,BrandManager>();
            services.AddScoped<IBrandRepo,BrandRepo>();

            services.AddScoped<ICustomerService,CustomerManager>();
            services.AddScoped<ICustomerRepo,CustomerRepo>();

            services.AddScoped<ICustomerContactService,CustomerContactManager>();
            services.AddScoped<ICustomerContactRepo,CustomerContactRepo>();

            services.AddScoped<ICustomerOrderService,CustomerOrderManager>();
            services.AddScoped<IOrderRepo,OrderRepo>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GuitarShop.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
