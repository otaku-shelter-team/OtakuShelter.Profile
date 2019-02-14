using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class ReadByIdProfileViewModel
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; private set; }

		public async Task ReadById(ProfileContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			Nickname = profile.Nickname;
		}
	}
}