using Phema.Routing;

namespace OtakuShelter.Profile
{
	public static class ProfilesControllerRoutes
	{
		public static IRoutingBuilder AddProfilesController(this IRoutingBuilder builder)
		{
			builder.AddController<ProfilesController>("profiles", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateProfileViewModel>()))
					.HttpPost()
					.Authorize();

				controller.AddRoute(c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("{accountId}", c => c.ReadById(From.Route<int>()))
					.HttpGet()
					.Authorize();

				controller.AddRoute(c => c.Update(From.Body<UpdateProfileViewModel>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute(c => c.Delete(From.Any<DeleteProfileViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin", c => c.AdminRead(From.Query<FilterViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/{profileId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/{profileId}",
						c => c.AdminUpdateById(From.Body<AdminUpdateByIdProfileViewModel>(), From.Route<int>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/{profileId}", c => c.AdminDeleteById(From.Route<AdminDeleteByIdProfileViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});

			return builder;
		}
	}
}