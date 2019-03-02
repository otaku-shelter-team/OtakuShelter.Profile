using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Profiles
{
	public class ProfilesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProfilesContext>
	{
		public ProfilesContext CreateDbContext(string[] args)
		{
			return new ServiceCollection()
				.AddProfilesDatabase(new ProfilesDatabaseConfiguration())
				.BuildServiceProvider()
				.GetRequiredService<ProfilesContext>();
		}
	}
}