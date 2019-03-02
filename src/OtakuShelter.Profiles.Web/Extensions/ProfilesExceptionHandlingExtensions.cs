using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Profiles
{
	public static class ProfilesExceptionHandlingExtensions
	{
		public static IServiceCollection AddProfilesExceptionHandling(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
					options.AddExceptionHandler<Exception, ProfilesExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}