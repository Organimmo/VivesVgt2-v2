using Blazored.LocalStorage;

namespace Organimmo.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
        }
	}
}
