using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Profile
{
	public static class ProfileHealthServices
	{
		public static IServiceCollection AddHealthServices(
			this IServiceCollection services,
			ProfileContextConfiguration database,
			ProfileRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);
			
			return services;
		}
	}
}