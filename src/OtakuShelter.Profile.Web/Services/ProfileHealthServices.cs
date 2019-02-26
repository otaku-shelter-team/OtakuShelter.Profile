using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Profile
{
	public static class ProfileHealthServices
	{
		public static IServiceCollection AddHealthServices(this IServiceCollection services, ProfileContextConfiguration database)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString);
			
			return services;
		}
	}
}