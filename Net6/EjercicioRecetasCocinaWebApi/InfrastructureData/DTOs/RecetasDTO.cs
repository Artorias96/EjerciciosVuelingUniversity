using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class RecetasDTO
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("ingredientes")]
        public Dictionary<string, decimal> Ingredientes { get; set; }

        [JsonPropertyName("minutosCocinado")]
        public int TiempoPreparacion { get; set; }

    }
}
