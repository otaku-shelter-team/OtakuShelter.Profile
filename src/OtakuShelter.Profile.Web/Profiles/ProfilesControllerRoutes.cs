using Phema.Routing;

namespace OtakuShelter.Profile
{
	public static class ProfilesControllerRoutes
	{
		public static IRoutingBuilder AddProfilesController(this IRoutingBuilder builder, ProfileRoleConfiguration roles)
		{
			builder.AddController<ProfilesController>(controller =>
			{
				controller.AddRoute("throw", c => c.Throw(From.Query<string>()))
					.HttpGet();
				
				controller.AddRoute("profiles", c => c.Create(From.Body<CreateProfileRequest>()))
					.HttpPost()
					.Authorize();

				controller.AddRoute("profiles", c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("{accountId}/profiles", c => c.ReadById(From.Route<int>()))
					.HttpGet()
					.Authorize();

				controller.AddRoute("profiles", c => c.Update(From.Body<UpdateProfileRequest>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("profiles", c => c.Delete(From.Any<DeleteProfileRequest>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin/profiles", c => c.AdminRead(From.Query<FilterRequest>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/profiles/{profileId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/profiles/{profileId}",
						c => c.AdminUpdateById(From.Body<AdminUpdateByIdProfileRequest>(), From.Route<int>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/profiles/{profileId}", c => c.AdminDeleteById(From.Route<AdminDeleteByIdProfileRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});

			return builder;
		}
	}
}