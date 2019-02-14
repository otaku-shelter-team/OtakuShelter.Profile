using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Profile
{
	public static class ProfileDataServices
	{
		public static IServiceCollection AddDataServices(
		this IServiceCollection services,
		ProfileContextConfiguration mangaContext)
		{
			services.AddDbContextPool<ProfileContext>(options =>
				ProfileContextFactory.ConfigureContext(options, mangaContext));

			return services;
		}
	}
}