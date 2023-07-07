using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{
    public class ProductsTranslationsFromJson
    {
        [JsonPropertyName("IdProduct")]
        public int IdProduct { get; set; }

        [JsonPropertyName("Translations")]
        public Dictionary<string, string> Translations { get; set; }
    }
}
