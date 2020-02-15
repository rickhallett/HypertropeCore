using System.IdentityModel.Tokens.Jwt;
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
            services.ConfigureJwt(configuration);
            
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            services.AddAuthentication();
            services.ConfigureIdentity();
            
            services.AddControllers();
            
            services.ConfigureSwagger();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        }
    }
}