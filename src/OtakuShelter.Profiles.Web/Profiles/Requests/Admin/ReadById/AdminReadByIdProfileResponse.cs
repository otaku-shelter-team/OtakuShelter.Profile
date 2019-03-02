using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class AdminReadByIdProfileResponse
	{
		[DataMember(Name = "accountId")]
		public int AccountId { get; private set; }
		
		[DataMember(Name = "nickname")]
		public string Nickname { get; private set; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; private set; }
		
		public async ValueTask Load(ProfilesContext context, int profileId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.Id == profileId);

			AccountId = profile.AccountId;
			Nickname = profile.Nickname;
			Created = profile.Created;
		}
	}
}