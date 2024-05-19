using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class PricePerYearDTO
    {
        [JsonPropertyName("prieceForLunarYear")]
        public decimal PrieceForLunarYear { get; set; }
    }
}
