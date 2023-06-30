using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.DataEntities
{


        public class CartDataEntity
        {
            public CartData[] Property1 { get; set; }
        }

        public class CartData
        {
            public int id { get; set; }
            public int userId { get; set; }
            public DateTime date { get; set; }
            public ProductCart[] products { get; set; }
            public int __v { get; set; }
        }

        public class ProductCart
        {
            public int productId { get; set; }
            public int quantity { get; set; }
        }

}

