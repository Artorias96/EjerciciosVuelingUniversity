using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class DistancePlanetDTO
    {
        public Dictionary<string, List<PlanetInfoDTO>> DistancePlanet { get; set; }
    }

    public class PlanetInfoDTO
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("lunarYears")]
        public decimal LunarYears { get; set; }

    }
}
