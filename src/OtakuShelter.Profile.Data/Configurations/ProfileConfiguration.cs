using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Profile.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("profiles");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.AccountId)
                .HasColumnName("accountid")
                .IsRequired();

            builder.HasIndex(p => p.AccountId)
                .HasName("UQ_accountid")
                .IsUnique();

            builder.Property(p => p.Nickname)
                .HasColumnName("nickname")
                .IsRequired();

            builder.Property(p => p.CreatedDateTimeUtc)
                .HasColumnName("createddatetimeutc")
                .IsRequired();
        }
    }
}