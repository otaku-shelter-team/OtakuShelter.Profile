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

		public async Task Create(CreateProfileViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Create(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task<ReadProfileViewModel> Read()
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var model = new ReadProfileViewModel();

			await model.Load(context, accountId);

			return model;
		}

		public async Task<ReadByIdProfileViewModel> ReadById(int accountId)
		{
			var model = new ReadByIdProfileViewModel();

			await model.ReadById(context, accountId);

			return model;
		}

		public async Task Update(UpdateProfileViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			await model.Update(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteProfileViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task<AdminReadProfileViewModel> AdminRead(FilterViewModel filter)
		{
			var model = new AdminReadProfileViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task<AdminReadByIdProfileViewModel> AdminReadById(int profileId)
		{
			var model = new AdminReadByIdProfileViewModel();

			await model.Load(context, profileId);

			return model;
		}

		public async Task AdminUpdateById(AdminUpdateByIdProfileViewModel model, int profileId)
		{
			await model.Update(context, profileId);

			await context.SaveChangesAsync();
		}

		public async Task AdminDeleteById(AdminDeleteByIdProfileViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}