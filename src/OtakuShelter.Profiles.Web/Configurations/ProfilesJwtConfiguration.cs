using System.Text;

using Microsoft.IdentityModel.Tokens;

using Phema.Configuration;

namespace OtakuShelter.Profiles
{
	[Configuration]
	public class ProfilesJwtConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		
		public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
	}
}