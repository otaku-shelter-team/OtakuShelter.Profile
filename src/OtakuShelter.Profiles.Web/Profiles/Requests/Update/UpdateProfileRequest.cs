using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class UpdateProfileRequest
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }

		public async ValueTask Update(ProfilesContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			if (Nickname != null)
			{
				profile.Nickname = Nickname;
			}
		}
	}
}