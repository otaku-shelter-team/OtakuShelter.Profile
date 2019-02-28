using Microsoft.Extensions.DependencyInjection;
using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Profile
{
	public static class ProfileRabbitMqServices
	{
		private const string ErrorsQueueName = "errors";
		
		public static IServiceCollection AddRabbitMqServices(
			this IServiceCollection services,
			ProfileRabbitMqConfiguration configuration)
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
			
			builder.AddQueues(options => 
				options.AddQueue(ErrorsQueueName)
					.Durable());

			builder.AddExchanges(options =>
				options.AddDirectExchange("amq.direct")
					.Durable());
			
			builder.AddProducers(options =>
				options.AddProducer<ErrorQueueMessage>("amq.direct", ErrorsQueueName)
					.Mandatory());
			
			return services;
		}
	}
}