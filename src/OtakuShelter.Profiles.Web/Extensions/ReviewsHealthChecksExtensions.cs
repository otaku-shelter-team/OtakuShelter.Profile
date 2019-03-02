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
	}
}