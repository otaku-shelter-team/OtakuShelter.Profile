using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	public class DeleteProfileViewModel
	{
		public async Task Delete(ProfileContext context, int accountId)
		{
			var profile = await context.Profiles.FirstAsync(p => p.AccountId == accountId);

			context.Profiles.Remove(profile);
		}
	}
}