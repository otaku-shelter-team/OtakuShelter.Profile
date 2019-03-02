using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Profiles
{
	public static class ProfilesMvcExtensions
	{
		public static IServiceCollection AddProfilesMvc(
			this IServiceCollection services,
			ProfilesRoleConfiguration roles)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing => 
					routing.AddProfilesController(roles)
					.AddVersionController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}