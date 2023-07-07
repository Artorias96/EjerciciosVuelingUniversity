using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class Products
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Rate { get; set; } = "";
        public string Discontinued { get; set; } = "";
    }
}
