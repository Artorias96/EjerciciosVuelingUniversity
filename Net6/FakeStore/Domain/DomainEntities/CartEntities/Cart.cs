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
        public int ProductsCartId { get; set; }
        public int ProductCardQuantity { get; set; }

    }
}
