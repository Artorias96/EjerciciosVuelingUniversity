using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IProductsRepository
    {
        ProductInfo GetAllProductsInfo();
        string DeleteProductById(int id);
        bool SaveDataInFile(string list);
        string CreateNewProduct(Product productToCreate);
        string UpdateProductById(int id, float newPrice);
    }
}
