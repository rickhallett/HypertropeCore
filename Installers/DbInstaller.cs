using System;
using HypertropeCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HypertropeCore.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<HypertropeCoreContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ProdDB"), builder => builder.MigrationsAssembly("STATE_MIGRATIONS")));
            }
            else
            {
                services.AddDbContext<HypertropeCoreContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("HypertropeNPQDev"), builder => builder.MigrationsAssembly("HypertropeCore") ));
            }
            
            services.BuildServiceProvider().GetService<HypertropeCoreContext>().Database.Migrate();
        }
    }
}