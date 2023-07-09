using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class PrecioCocinadoDTO
    {
        [JsonPropertyName("CostePorMinuto")]
        public decimal CostePorMinuto { get; set; }
    }
}
