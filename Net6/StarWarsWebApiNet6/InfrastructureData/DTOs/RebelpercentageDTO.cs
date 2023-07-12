using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class RebelpercentageDTO
    {
        [JsonPropertyName("planetName")]
        public string PlanetName { get; set; }
        [JsonPropertyName("rebelPercent")]
        public string RebelPercent { get; set;}
    }

}
