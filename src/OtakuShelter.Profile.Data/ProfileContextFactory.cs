using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Phema.Configuration.Yaml;

namespace OtakuShelter.Profile
{
	public class ProfileContextFactory : IDesignTimeDbContextFactory<ProfileContext>
	{
		public ProfileContext CreateDbContext(string[] args)
		{
			var configurationBuilder = new ConfigurationBuilder();
			ConfigureBuilder(configurationBuilder, Directory.GetCurrentDirectory());
			var configuration = configurationBuilder.Build();

			var database = configuration.GetSection("database").Get<ProfileContextConfiguration>();

			var optionsBuilder = new DbContextOptionsBuilder<ProfileContext>();
			ConfigureContext(optionsBuilder, database);
			var options = optionsBuilder.Options;

			return new ProfileContext(options);
		}

		public static void ConfigureBuilder(IConfigurationBuilder builder, string path)
		{
			builder.SetBasePath(path)
				.AddYamlFile("appsettings.yml")
				// TODO: Move to appsettings.yml
				.AddEnvironmentVariables("OTAKUSHELTER:");
		}

		public static void ConfigureContext(DbContextOptionsBuilder options, ProfileContextConfiguration database)
		{
			options.UseNpgsql(database.ConnectionString, builder =>
					builder.MigrationsHistoryTable(database.MigrationsTable))
				.UseLazyLoadingProxies();
		}
	}
}