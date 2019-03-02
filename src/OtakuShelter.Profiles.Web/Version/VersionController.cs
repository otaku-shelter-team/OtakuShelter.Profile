using Microsoft.Extensions.Options;

namespace OtakuShelter.Profiles
{
	public class VersionController
	{
		private readonly ProfilesConfiguration configuration;

		public VersionController(IOptions<ProfilesConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public ReadVersionResponse Version()
		{
			var response = new ReadVersionResponse();

			response.Read(configuration);

			return response;
		}
	}
}