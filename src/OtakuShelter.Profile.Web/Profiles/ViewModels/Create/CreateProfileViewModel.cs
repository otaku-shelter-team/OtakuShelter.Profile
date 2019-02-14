using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class CreateProfileViewModel
	{
		[DataMember(Name = "nickname")]
		public string Nickname { get; set; }

		public async Task Create(ProfileContext context, int accountId)
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