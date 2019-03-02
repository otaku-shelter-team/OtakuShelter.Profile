using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Profiles
{
	public static class ProfilesHealthChecksExtensions
	{
		public static IServiceCollection AddProfilesHealthChecks(
			this IServiceCollection services,
			ProfilesDatabaseConfiguration database,
			ProfilesRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);
			
			return services;
		}
		
		public static IApplicationBuilder UseProfilesHealthchecks(this IApplicationBuilder app)
		{
			return app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		}
	}
}