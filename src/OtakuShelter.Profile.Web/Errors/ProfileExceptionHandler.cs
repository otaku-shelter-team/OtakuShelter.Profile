using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Profile
{
	public class ProfileExceptionHandler : IExceptionHandler<Exception>
	{
		private readonly IRabbitMqProducer<ErrorQueueMessage> producer;

		public ProfileExceptionHandler(IRabbitMqProducer<ErrorQueueMessage> producer)
		{
			this.producer = producer;
		}
		
		public async ValueTask<IActionResult> Handle(Exception exception)
		{
			var message = new ErrorQueueMessage
			{
				Type = exception.GetType().ToString(),
				Project = "profile",
				Message = exception.Message,
				StackTrace = exception.StackTrace,
				Created = DateTime.UtcNow
			};

			await producer.Produce(message);
			
			return new BadRequestObjectResult(new {error = exception.Message});
		}
	}
}