using Phema.Configuration;

namespace OtakuShelter.Profile
{
	[Configuration]
	public class ProfileWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }

		public ProfileContextConfiguration Database { get; set; }
	}
}