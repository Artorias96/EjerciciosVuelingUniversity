using Domain.DomainEntities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IProductsRepository
    {
        ProductList GetAllProductsInfo();
        ProductList GetActualProductsList();
        string DeleteProductById(int id);
        bool SaveProductsInFile(string list);
        string CreateNewProduct(Product productToCreate);
        string UpdateProductById(int id, float newPrice);
    }
}
