using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class AdminReadByIdProfileViewModel
	{
		[DataMember(Name = "accountId")]
		public int AccountId { get; private set; }
		
		[DataMember(Name = "nickname")]
		public string Nickname { get; private set; }
		
		[DataMember(Name = "createdDateTimeUtc")]
		public DateTime CreatedDateTimeUtc { get; private set; }
		
		public async Task Load(ProfileContext context, int profileId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.Id == profileId);

			AccountId = profile.AccountId;
			Nickname = profile.Nickname;
			CreatedDateTimeUtc = profile.CreatedDateTimeUtc;
		}
	}
}