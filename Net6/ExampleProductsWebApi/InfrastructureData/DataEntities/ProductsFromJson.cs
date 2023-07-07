using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{
    public class ProductsFromJson
    {
        [JsonPropertyName("Id")]    
        public int Id { get; set; }
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }
        [JsonPropertyName("Rate")]
        public int Rate { get; set; }
        [JsonPropertyName("Discontinued")]
        public string Discontinued { get; set; } = "";
    }
}
