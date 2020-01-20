using System;
using AutoMapper;
using HypertropeCore.Context;
using HypertropeCore.Extensions;
using HypertropeCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HypertropeCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionConfig = Configuration.GetSection("ConnectionString");

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<HypertropeCoreContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProdDB")));
            }
            else
            {
                services.AddDbContext<HypertropeCoreContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("DevDB")));
            }
            
            // TODO: use DI here
            services.BuildServiceProvider().GetService<HypertropeCoreContext>().Database.Migrate();
            
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            services.AddAuthentication();
            services.ConfigureIdentity();
            
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IWorkoutService, WorkoutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowAllCors");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}