using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using O73Z62_HFT_2022231.Logic;
using O73Z62_HFT_2022231.Logic.Interfaces;
using O73Z62_HFT_2022231.Logic.Services;
using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository;
using O73Z62_HFT_2022231.Repository.Interfaces;
using O73Z62_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.EndpointNew
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
            services.AddTransient<CarRenterDbContext>();

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IRenterRepository, RenterRepository>();

            services.AddTransient<ICompanyLogic, CompanyLogic>();
            services.AddTransient<ICarLogic, CarLogic>();
            services.AddTransient<IRenterLogic, RenterLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "O73Z62_HFT_2022231.EndpointNew", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "O73Z62_HFT_2022231.EndpointNew v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()
                .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
