using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HypertropeCore.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}