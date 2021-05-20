using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entities;
using Api.Services;
using Api.Services.Interfaces;
using Api.Services.Profiles;
using Api.Services.Repositories;
using Api.Services.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Api
{
    public class Startup
    {
        readonly string myOrigin = "_myOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // cors
            services.AddCors(c =>
            {
                c.AddPolicy("TCAPolicy", builder =>
                {
                    builder.SetIsOriginAllowed(s => true)
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<IProjectsTasksRepository, ProjectsTasksRepository>();
            services.AddScoped<IProjectTasksService, ProjectTaskService>();

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            });
               /* .AddXmlDataContractSerializerFormatters()
              .AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });*/

            services.AddDbContext<ProjectTrackerContext>
                (opt => opt.UseSqlServer(Configuration.GetConnectionString("ProjectsTrackerDb")));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("TCAPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
