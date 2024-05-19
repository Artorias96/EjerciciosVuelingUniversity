using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class ViviendasDTO
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("IdBarrio")]
        public int IdBarrio { get; set; }
        [JsonPropertyName("M2")]
        public decimal M2 { get; set; }

        [JsonPropertyName("Añadidos")]
        public Dictionary<string, decimal> Añadidos { get; set; }
    }
}
