using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{
    public class PeopleNeedForMeetingDictionaryFromJson
    {
        public Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> Dictionary { get; set; } = new();
    }
}
