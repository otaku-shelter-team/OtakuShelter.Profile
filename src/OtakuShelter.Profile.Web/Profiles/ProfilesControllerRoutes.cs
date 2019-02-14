using Phema.Routing;

namespace OtakuShelter.Profile
{
    public static class ProfilesControllerRoutes
    {
        public static IRoutingBuilder AddProfilesController(this IRoutingBuilder builder)
        {
            builder.AddController<ProfilesController>(controller => { });
            
            return builder;
        }
    }
}