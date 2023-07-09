using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.ServiceContracts
{
    public interface IProductsConversionsService
    {
        Task <List<ProductsConversions>> GetAllProductsConversions(string sku);
    }
}
