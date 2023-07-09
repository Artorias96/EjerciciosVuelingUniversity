using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class ProductsConversionsDTO
    {
        [JsonPropertyName("sku")]
        public string Sku { get; set; }
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
