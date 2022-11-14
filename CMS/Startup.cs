using CMS.DAL.MongoDb;
using CMS.Database.CMSDb;
using CMS.Database.UserDb;
using CMS.JWT;
using CMS.Models.DbModels;
using CMS.Policy1.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace CMS
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
            services.RegisterJwtServices();

           // services.AddJwtBearerAuthentication();
            //services.AddRolesAndPolicyAuthorization();
            services.AddControllers();
            //services.Configure<UserDbSettings>(
            //    Configuration.GetSection("UserDbSettings"));
            services.Configure<DatabaseSettings>(
               Configuration.GetSection("CMSDatabaseSettings"));
           // DbInitialization.getInstance().DbConnection();


            services.AddSingleton<IAuthorizationHandler, ShouldBeAnAuthorizedHandler>();
            services.AddSingleton<UserService>();
            services.AddSingleton<CMSService>();
            services.AddSingleton<DbInitialization>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
