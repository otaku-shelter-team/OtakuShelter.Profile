using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class ReadProfileViewModel
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }

		[DataMember(Name = "createdDateTimeUtc")]
		public DateTime CreatedDateTimeUtc { get; set; }

		public async Task Load(ProfileContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			Nickname = profile.Nickname;
			CreatedDateTimeUtc = profile.CreatedDateTimeUtc;
		}
	}
}