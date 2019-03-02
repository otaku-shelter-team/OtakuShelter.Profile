using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class ReadProfileResponse
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }

		[DataMember(Name = "created")]
		public DateTime Created { get; set; }

		public async ValueTask Load(ProfilesContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			Nickname = profile.Nickname;
			Created = profile.Created;
		}
	}
}