using System.Runtime.Serialization;

namespace OtakuShelter.Profile
{
    [DataContract]
    public class ReadProfileItemViewModel
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }
}