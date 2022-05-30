using Organimmo.API.Installers.Abstractions;

namespace Organimmo.API.Installers
{
    public class ApiInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }
    }
}
