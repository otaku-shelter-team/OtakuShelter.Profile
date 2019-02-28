using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Profile
{
	public static class ProfileExceptionHandlerServices
	{
		public static IServiceCollection AddExceptionHandlingServices(this IServiceCollection services)
		{
			
			return services.AddPhemaExceptionHandling(options =>
				options.AddExceptionHandler<Exception, ProfileExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}