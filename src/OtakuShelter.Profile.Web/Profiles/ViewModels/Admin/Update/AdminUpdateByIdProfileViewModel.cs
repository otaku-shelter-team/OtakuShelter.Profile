using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class AdminUpdateByIdProfileViewModel
	{
		[DataMember(Name = "accountId")]
		public int? AccountId { get; set; }
		
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }
		
		public async Task Update(ProfileContext context, int profileId)
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