using System;
using System.Security.Principal;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Profile
{
	public class ProfileExceptionHandler : IExceptionHandler<Exception>
	{
		private readonly IRabbitMqProducer<ErrorQueueMessage> producer;
		private readonly IHttpContextAccessor accessor;

		public ProfileExceptionHandler(IRabbitMqProducer<ErrorQueueMessage> producer, IHttpContextAccessor accessor)
		{
			this.producer = producer;
			this.accessor = accessor;
		}
		
		public async ValueTask<IActionResult> Handle(Exception exception)
		{
			var message = new ErrorQueueMessage
			{
				TraceId = accessor.HttpContext.TraceIdentifier,
				Type = exception.GetType().ToString(),
				Project = "profile",
				Message = exception.Message,
				StackTrace = exception.StackTrace,
				Created = DateTime.UtcNow
			};

			await producer.Produce(message);
			
			return new BadRequestObjectResult(new {traceId = message.TraceId});
		}
	}
}