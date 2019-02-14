using Microsoft.EntityFrameworkCore;
using OtakuShelter.Profile.Configurations;

namespace OtakuShelter.Profile
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
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