using Organimmo.API.Installers.Abstractions;
using Organimmo.SDK;
using Organimmo.SDK.Contract;
using Organimmo.Services;
using Organimmo.Services.Abstractions;

namespace Organimmo.API.Installers
{
    public class ServicesInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITranslateService, TranslateService>();

        }

        //public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services, int i = 0)
        //{
        //    // repository    
        //    services.AddScoped<YourIRepositoryClass, YourRepositoryClass>();
        //    //services    
        //    services.AddScoped<YourIServiceClass, YourServiceClass>();
        //    //services.AddScoped<IMasterMenuProvider, MasterMenuProvider>();
        //    return services;
        //}
    }
}
