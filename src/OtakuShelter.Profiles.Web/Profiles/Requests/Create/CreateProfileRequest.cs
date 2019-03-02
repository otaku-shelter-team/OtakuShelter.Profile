using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class CreateProfileRequest
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }

		public async ValueTask Create(ProfilesContext context, int accountId)
		{
			var profile = new Profile
			{
				Nickname = Nickname,
				AccountId = accountId,
				Created = DateTime.UtcNow
			};

			await context.Profiles.AddAsync(profile);
		}
	}
}