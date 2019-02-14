using System;

namespace OtakuShelter.Profile
{
    public class Profile
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Nickname { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
    }
}