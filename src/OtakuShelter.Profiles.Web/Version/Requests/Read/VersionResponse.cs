using System.Runtime.Serialization;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class ReadVersionResponse
	{
		[DataMember(Name = "version")]
		public string Version { get; set; }

		public void Read(ProfilesConfiguration configuration)
		{
			Version = configuration.Version;
		}
	}
}