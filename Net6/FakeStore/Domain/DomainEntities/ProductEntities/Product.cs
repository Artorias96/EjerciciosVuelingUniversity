using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities.ProductEntities
{
    public class Product
    {
        public int id { get; set; }

        public float price { get; set; }

        public string? description { get; set; }

        public string? category { get; set; }
    }
}
