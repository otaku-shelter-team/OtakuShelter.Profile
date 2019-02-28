using System;

using Microsoft.AspNetCore.Mvc.Filters;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Profile
{
	public class ProfileExceptionHandler : IExceptionHandler
	{
		private readonly IRabbitMqProducer<ErrorQueueMessage> producer;

		public ProfileExceptionHandler(IRabbitMqProducer<ErrorQueueMessage> producer)
		{
			this.producer = producer;
		}
		
		public void HandleException(ExceptionContext context)
		{
			var message = new ErrorQueueMessage
			{
				Type = context.Exception.GetType().ToString(),
				Project = "profile",
				Message = context.Exception.Message,
				StackTrace = context.Exception.StackTrace,
				Created = DateTime.UtcNow
			};

			producer.Produce(message).GetAwaiter().GetResult();
		}
	}
}