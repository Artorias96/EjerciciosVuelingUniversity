using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class PlanetsDTO
    {
        [JsonPropertyName("planetName")]
        public string PlanetName { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set;}
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
    }
}