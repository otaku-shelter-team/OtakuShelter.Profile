using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class AdminDeleteByIdProfileViewModel
	{
		[DataMember(Name = "profileId")]
		public int ProfileId { get; set; }
		
		public async Task Delete(ProfileContext context)
		{
			var profile = await context.Profiles.FirstAsync(p => p.Id == ProfileId);

			context.Profiles.Remove(profile);
		}
	}
}