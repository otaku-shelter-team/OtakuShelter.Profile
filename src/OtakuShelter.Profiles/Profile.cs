using System;

namespace OtakuShelter.Profiles
{
	public class Profile
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public string Nickname { get; set; }
		// Image
		// Rating
		public DateTime Created { get; set; }
	}
}