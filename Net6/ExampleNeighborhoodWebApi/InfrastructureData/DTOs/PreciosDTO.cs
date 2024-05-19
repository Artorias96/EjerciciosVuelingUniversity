using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class PreciosDTO
    {
        public Dictionary<string, CondicionesCosteDTO> Añadidos { get; set; }
    }

    public class CondicionesCosteDTO
    {
        [JsonPropertyName("precioM2")]
        public decimal PrecioM2 { get; set; }
        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }

    }
}
