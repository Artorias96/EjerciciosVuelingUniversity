using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class BarriosDTO
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("CosteM2")]
        public decimal CosteM2 { get; set; }
    }
}
