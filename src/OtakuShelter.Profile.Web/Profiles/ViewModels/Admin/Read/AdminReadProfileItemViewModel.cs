using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Profile
{
	[DataContract]
	public class AdminReadProfileItemViewModel
	{
		public AdminReadProfileItemViewModel(Profile profile)
		{
			Id = profile.Id;
			AccountId = profile.AccountId;
			Nickname = profile.Nickname;
			Created = profile.Created;
		}

		[DataMember(Name = "id")]
		public int Id { get; }

		[DataMember(Name = "accountId")]
		public int AccountId { get; }
		
		[DataMember(Name = "nickname")]
		public string Nickname { get; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; }
	}
}