using HypertropeCore.Extensions;
using HypertropeCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HypertropeCore.Installers
{
    public class ScopedServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            
            services.ConfigureLoggerService();
        }
    }
}