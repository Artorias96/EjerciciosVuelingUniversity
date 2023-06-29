using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{

        public class ProductDataEntity
        {
            public ProductData[]? Property1 { get; set; }
        }

        public class ProductData
    {
            public int id { get; set; }
            public string? title { get; set; }
            public float price { get; set; }
            public string? description { get; set; }
            public string? category { get; set; }
            public string? image { get; set; }
            public Rating? rating { get; set; }
        }

        public class Rating
        {
            public float rate { get; set; }
            public int count { get; set; }
        }
}

