using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{
    public class MusicianInfoFromJson
    {
        [JsonPropertyName("Nombre")]
        public string Name {  get; set; } = "";
        [JsonPropertyName("Categorías")]
        public string Roles { get; set; } = "";
    }
}
