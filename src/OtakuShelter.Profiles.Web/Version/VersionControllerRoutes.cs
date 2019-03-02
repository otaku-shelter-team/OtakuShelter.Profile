using Phema.Routing;

namespace OtakuShelter.Profiles
{
	public static class VersionControllerRoutes
	{
		public static IRoutingBuilder AddVersionController(this IRoutingBuilder builder)
		{
			builder.AddController<VersionController>(controller =>
			{
				controller.AddRoute("version", c => c.Version())
					.HttpGet();
			});
			
			return builder;
		}
	}
}