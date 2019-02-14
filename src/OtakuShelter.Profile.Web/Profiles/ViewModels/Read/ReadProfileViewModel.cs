using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OtakuShelter.Profile
{
    [DataContract]
    public class ReadProfileViewModel
    {
        [DataMember(Name = "profiles")]
        public ICollection<ReadProfileItemViewModel> Profiles { get; set; }
    }
}