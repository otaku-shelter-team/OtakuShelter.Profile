using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class AdminReadProfileViewModel
	{
		[DataMember(Name = "profiles")]
		public ICollection<AdminReadProfileItemViewModel> Profiles { get; private set; }

		public async Task Load(ProfileContext context, int offset, int limit)
		{
			Profiles = await context.Profiles
				.OrderByDescending(p => p.Created)
				.Skip(offset)
				.Take(limit)
				.Select(p => new AdminReadProfileItemViewModel(p))
				.ToListAsync();
		}
	}
}