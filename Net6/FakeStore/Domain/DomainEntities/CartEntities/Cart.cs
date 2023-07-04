using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities.CartEntities
{
    public class Cart
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime Date { get; set; }
        public ProductsCart[]? products { get; set; }

    }
    public class ProductsCart
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
