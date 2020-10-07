using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenericAPI.Domain.Persistence.Contexts;
using GenericAPI.Domain.Repositories;
using GenericAPI.Domain.Services;
using GenericAPI.Persistence.Repositories;
using GenericAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericAPI
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

            //Declare what DataBase is going to be used
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("GenericAPI-api-in-memory");
            });

            //Declare relations between Interfaces and classes
            services.AddScoped<IExampleClassRepository, ExampleClassRepository>();
            services.AddScoped<IExampleClassService, ExampleClassService>();

            services.AddScoped<IExampleSubClassRepository, ExampleSubClassRepository>();
            services.AddScoped<IExampleSubClassService, ExampleSubClassService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //AutoMapper declared
            services.AddAutoMapper(typeof(Startup));
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
