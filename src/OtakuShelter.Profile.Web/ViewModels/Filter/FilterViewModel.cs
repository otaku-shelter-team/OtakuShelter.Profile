using System.Runtime.Serialization;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class FilterViewModel
	{
		[DataMember(Name = "offset")]
		public int Offset { get; set; }

		[DataMember(Name = "limit")]
		public int Limit { get; set; } = 10;
	}
}