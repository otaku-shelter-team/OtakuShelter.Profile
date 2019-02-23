using System.Text;

using Microsoft.IdentityModel.Tokens;

using Phema.Configuration;

namespace OtakuShelter.Profile
{
	[Configuration]
	public class ProfileWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }

		public ProfileRoleConfiguration Roles { get; set; }
		public ProfileContextConfiguration Database { get; set; }

		public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
	}
}