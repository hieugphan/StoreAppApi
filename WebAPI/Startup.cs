using BusinessLogic;
using DataLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            //reference dbcontext because it's responsible for communicating with DB
            services.AddDbContext<DBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Reference2DB")));

            //Add dependencies dl and bl
            services.AddScoped<IDL, DataLogic.DL>();
            services.AddScoped<IBL, BL>();

            //Configuring CORS in our web api to accept the local address in our Angular project
            //localhost = http://127.0.0.1
            //after deploy the api address would be in webservice properties virtual IP address
            //angular localhost = http://127.0.0.1:4200

            services.AddCors(
                (builder) =>
                {
                    //this is where you add trusted domain
                    builder.AddDefaultPolicy((policy) =>
                    {
                        policy.WithOrigins("http://127.0.0.1:4200", "https://hieuphanrrangular.azurewebsites.net/", "https://40.89.243.164/", "http://40.89.243.164/") //This is where you create the address that you want to trust
                            .AllowAnyHeader() //Allows any header
                            .AllowAnyMethod(); //Allows any http verb method
                    });
                        
                }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
