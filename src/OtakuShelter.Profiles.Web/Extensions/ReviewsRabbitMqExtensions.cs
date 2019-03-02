using Microsoft.Extensions.DependencyInjection;

using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Profiles
{
	public static class ProfilesRabbitMqExtensions
	{
		public static IServiceCollection AddProfilesRabbitMq(
			this IServiceCollection services,
			ProfilesRabbitMqConfiguration configuration)
		{
			services.AddPhemaJsonSerializer();
			
			var builder = services.AddPhemaRabbitMq(configuration.InstanceName,
				options =>
				{
					options.UserName = configuration.Username;
					options.Password = configuration.Password;
					options.Port = configuration.Port;
					options.HostName = configuration.Hostname;
					options.VirtualHost = configuration.VirtualHost;
				});
			
			builder.AddProducers(options =>
				options.AddProducer<ProfilesExceptionPayload>("amq.direct", "errors")
					.Mandatory());
			
			return services;
		}
	}
}