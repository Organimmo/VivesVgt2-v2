using MudBlazor;
using MudBlazor.Services;
using Organimmo.Services;
using Organimmo.Services.Abstractions;

namespace Organimmo.API
{
    using global::Organimmo.Services;
    using global::Organimmo.Services.Abstractions;
    using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.HttpsPolicy;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.Extensions.Logging;
	using Microsoft.OpenApi.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	namespace Organimmo.API
	{
		public class Startup
		{
			private const string CorsPolicyName = "CorsPolicy";

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public static readonly ILoggerFactory ConsoleLoggerFactory
                = LoggerFactory.Create(builder => { builder.AddConsole(); });

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {

                services.AddCors(options =>
                {
                    options.AddPolicy(name: CorsPolicyName,
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });

                services.AddControllers();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Organimmo.API", Version = "v1" });
                });


				services.AddTransient<ITranslateService, TranslateService>();
    
			}

			// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
			public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
			{
				if (env.IsDevelopment())
				{
					app.UseDeveloperExceptionPage();
					app.UseSwagger();
					app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Organimmo.API v1"));


				}

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseCors(CorsPolicyName);

				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllers();
				});
			}
		}
	}
}
