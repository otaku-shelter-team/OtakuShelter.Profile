using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Profile
{
	public static class ProfileMvcServices
	{
		public static IServiceCollection AddMvcServices(
			this IServiceCollection services,
			ProfileRoleConfiguration roles)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing => routing.AddProfilesController(roles))
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}