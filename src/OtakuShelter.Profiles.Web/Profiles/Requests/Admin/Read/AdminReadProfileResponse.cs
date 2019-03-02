using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class AdminReadProfileResponse
	{
		[DataMember(Name = "profiles")]
		public ICollection<AdminReadProfileItemResponse> Profiles { get; private set; }

		public async ValueTask Load(ProfilesContext context, int offset, int limit)
		{
			Profiles = await context.Profiles
				.OrderByDescending(p => p.Created)
				.Skip(offset)
				.Take(limit)
				.Select(p => new AdminReadProfileItemResponse(p))
				.ToListAsync();
		}
	}
}