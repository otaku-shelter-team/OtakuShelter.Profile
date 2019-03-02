namespace OtakuShelter.Profiles
{
	public class ProfilesConfiguration
	{
		public string Name { get; set; }
		
		public ProfilesDatabaseConfiguration Database { get; set; }
		public ProfilesJwtConfiguration Jwt { get; set; }
		public ProfilesRabbitMqConfiguration RabbitMq { get; set; }
		public ProfilesRoleConfiguration Roles { get; set; }
	}
}