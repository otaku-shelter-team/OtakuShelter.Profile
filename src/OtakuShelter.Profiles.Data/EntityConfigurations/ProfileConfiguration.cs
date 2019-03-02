using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Profiles
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
				.HasColumnName("account_id")
				.IsRequired();

			builder.HasIndex(p => p.AccountId)
				.HasName("UQ_account_id")
				.IsUnique();

			builder.Property(p => p.Nickname)
				.HasColumnName("nickname")
				.IsRequired();

			builder.Property(p => p.Created)
				.HasColumnName("created")
				.IsRequired();
		}
	}
}