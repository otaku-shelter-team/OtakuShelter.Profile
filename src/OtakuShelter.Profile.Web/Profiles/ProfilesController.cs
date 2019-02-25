using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace OtakuShelter.Profile
{
	public class ProfilesController : ControllerBase
	{
		private readonly ProfileContext context;

		public ProfilesController(ProfileContext context)
		{
			this.context = context;
		}

		public async ValueTask Create(CreateProfileRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Create(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask<ReadProfileResponse> Read()
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var response = new ReadProfileResponse();

			await response.Load(context, accountId);

			return response;
		}

		public async ValueTask<ReadByIdProfileResponse> ReadById(int accountId)
		{
			var response = new ReadByIdProfileResponse();

			await response.ReadById(context, accountId);

			return response;
		}

		public async ValueTask Update(UpdateProfileRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			await request.Update(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask Delete(DeleteProfileRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask<AdminReadProfileResponse> AdminRead(FilterRequest filter)
		{
			var response = new AdminReadProfileResponse();

			await response.Load(context, filter.Offset, filter.Limit);

			return response;
		}

		public async ValueTask<AdminReadByIdProfileResponse> AdminReadById(int profileId)
		{
			var response = new AdminReadByIdProfileResponse();

			await response.Load(context, profileId);

			return response;
		}

		public async ValueTask AdminUpdateById(AdminUpdateByIdProfileRequest request, int profileId)
		{
			await request.Update(context, profileId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDeleteById(AdminDeleteByIdProfileRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}