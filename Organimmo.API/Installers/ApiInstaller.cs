using Organimmo.API.Installers.Abstractions;
using Organimmo.SDK;
using Organimmo.SDK.Contract;

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
