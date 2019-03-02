using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class AdminDeleteByIdProfileRequest
	{
		[DataMember(Name = "profileId")]
		public int ProfileId { get; set; }
		
		public async ValueTask Delete(ProfilesContext context)
		{
			var profile = await context.Profiles.FirstAsync(p => p.Id == ProfileId);

			context.Profiles.Remove(profile);
		}
	}
}