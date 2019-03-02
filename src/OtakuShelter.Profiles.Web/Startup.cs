using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Profiles
{
	public class Startup : IStartup
	{
		private readonly ProfilesConfiguration configuration;

		public Startup(IOptions<ProfilesConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddProfilesSwagger()
				.AddProfilesExceptionHandling()
				.AddProfilesMvc(configuration.Roles)
				.AddProfilesDatabase(configuration.Database)
				.AddProfilesRabbitMq(configuration.RabbitMq)
				.AddProfilesAuthentication(configuration.Jwt)
				.AddProfilesHealthChecks(configuration.Database, configuration.RabbitMq)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();

			app.UseProfilesHealthchecks();
			app.UseAuthentication();
			app.UseProfilesSwagger();
			app.UseMvc();
		}
	}
}