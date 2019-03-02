using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Profiles
{
	public static class ProfilesDatabaseExtensions
	{
		public static IServiceCollection AddProfilesDatabase(
			this IServiceCollection services,
			ProfilesDatabaseConfiguration configuration)
		{
			services.AddDbContextPool<ProfilesContext>(options =>
				options.UseNpgsql(configuration.ConnectionString, builder =>
						builder.MigrationsHistoryTable(configuration.MigrationsTable))
					.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning)));

			return services;
		}
	}
}