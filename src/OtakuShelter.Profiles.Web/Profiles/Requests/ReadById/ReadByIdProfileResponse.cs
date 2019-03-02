using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class ReadByIdProfileResponse
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; private set; }

		public async ValueTask ReadById(ProfilesContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			Nickname = profile.Nickname;
		}
	}
}