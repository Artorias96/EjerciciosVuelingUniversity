using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{
    public class UnavailableDaysInfoFromJson
    {
        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Fechas")]
        public List<string> UnavaiableDays { get; set; } = new List<string>();
    }
}
