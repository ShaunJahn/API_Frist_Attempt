using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; //for logging inject a IloggerFactory
using NLog.Extensions.Logging;
using PetOwnerAPI.Entities;
using PetOwnerAPI.ServiceImplementations;
using PetOwnerAPI.Services;
using PetOwnerAPI.Models;

namespace PetOwnerAPI
{
    public class Startup
    {
        public static IConfiguration Config;

        //setup configuration for JSON access
        public Startup(IConfiguration configuration)
        {
            Config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
            //setup database connection strings
            var connectionString = Startup.Config["ConnectionStrings:PetsDBConnectionString"];
            services.AddDbContext<OwnerPetsContext>(c => c.UseSqlServer(connectionString));

            //add IOwnerPetsRepository
            services.AddScoped<IOwnerPetsRepository, OwnerPetsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,OwnerPetsContext ownerPetsContext)
        {

            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ownerPetsContext.EnsureSeedDataForContext();
            
            

            //set up MVC controler,models
            app.UseStatusCodePages();


            //map entinites with Dtos

            AutoMapper.Mapper.Initialize(cfg =>
           {
               //  cfg.CreateMap<Entities.Owner, OwnerDto>();
               cfg.CreateMap<Entities.Owner, Models.OwnerDto>();
               cfg.CreateMap<Entities.PetInfos, Models.PetInfoDto>();

               cfg.CreateMap<Models.PetInfoCreationDto, Entities.PetInfos>();
               cfg.CreateMap<PetInfoUpdateDto, PetInfos>();

           });

            app.UseMvc();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Default Page");
            });
        }
    }
}
