using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Profile
{
	public class Startup : IStartup
	{
		private readonly ProfileWebConfiguration configuration;

		public Startup(IOptions<ProfileWebConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddDataServices(configuration.Database)
				.AddMvcServices(configuration.Roles)
				.AddAuthenticationServices(configuration)
				.AddSwaggerServices()
				.AddHealthServices(configuration.Database)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();

			app.UseHealthChecks("/health");
			
			app.UseAuthentication();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Profile API v1");
				options.DocumentTitle = "OtakuShelter Profile API";
				options.DocExpansion(DocExpansion.List);
			});

			app.UseMvc();
		}
	}
}