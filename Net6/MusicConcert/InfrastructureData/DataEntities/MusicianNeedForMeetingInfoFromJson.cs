using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{
    public class MusicianNeedForMeetingInfoFromJson
    {
        [JsonPropertyName("category")]
        public string Role { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
