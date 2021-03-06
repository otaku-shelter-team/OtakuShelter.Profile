using System.Runtime.Serialization;

namespace OtakuShelter.Profiles
{
	[DataContract]
	public class FilterRequest
	{
		[DataMember(Name = "offset")]
		public int Offset { get; set; }

		[DataMember(Name = "limit")]
		public int Limit { get; set; } = 10;
	}
}