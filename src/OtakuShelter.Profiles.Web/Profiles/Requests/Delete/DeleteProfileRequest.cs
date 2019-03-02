using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	public class DeleteProfileRequest
	{
		public async ValueTask Delete(ProfilesContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			context.Profiles.Remove(profile);
		}
	}
}