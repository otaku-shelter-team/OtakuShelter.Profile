using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Profiles
{
	public class ProfilesContext : DbContext
	{
		public ProfilesContext(DbContextOptions<ProfilesContext> options)
			: base(options)
		{
		}

		public DbSet<Profile> Profiles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProfileConfiguration());
		}
	}
}