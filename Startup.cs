using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practincado.Domain.Persistence.Contexts;
using Practincado.Domain.Respositories;
using Practincado.Persistence.Respositories;
using Practincado.Domain.Services;
using Practincado.Services;

namespace Practincado
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("supermarket-api-in-memory");

            });

            // Repositories
            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IUrgenciRepository, UrgencieRepository>();


            services.AddRouting(options => options.LowercaseUrls = true);
            // Services
            services.AddScoped<IGuardianService, GuardinaService>();
            services.AddScoped<IUrgenciRepository, UrgencieRepository>();


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
