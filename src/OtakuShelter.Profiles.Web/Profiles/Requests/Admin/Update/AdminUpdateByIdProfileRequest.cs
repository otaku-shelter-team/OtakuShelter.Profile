using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class AdminUpdateByIdProfileRequest
	{
		[DataMember(Name = "accountId")]
		public int? AccountId { get; set; }
		
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }
		
		public async ValueTask Update(ProfilesContext context, int profileId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.Id == profileId);

			if (AccountId != null)
			{
				profile.AccountId = AccountId.Value;
			}

			if (Nickname != null)
			{
				profile.Nickname = Nickname;
			}
		}
	}
}