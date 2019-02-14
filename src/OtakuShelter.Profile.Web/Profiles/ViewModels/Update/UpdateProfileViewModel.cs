using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class UpdateProfileViewModel
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }

		public async Task Update(ProfileContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			if (Nickname != null)
			{
				profile.Nickname = Nickname;
			}
		}
	}
}