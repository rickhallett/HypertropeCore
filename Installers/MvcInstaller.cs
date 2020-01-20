using AutoMapper;
using HypertropeCore.Extensions;
using HypertropeCore.Options;
using HypertropeCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HypertropeCore.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            services.AddAuthentication();
            services.ConfigureIdentity();
            
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IWorkoutService, WorkoutService>();
        }
    }
}