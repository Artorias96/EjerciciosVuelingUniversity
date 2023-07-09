using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class ProductsConversions
    {
        public string Sku { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
