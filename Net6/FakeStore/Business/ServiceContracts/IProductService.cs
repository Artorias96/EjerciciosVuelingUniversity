using Domain.DomainEntities;

namespace Business.ServiceContracts
{
    public interface IProductService
    {
        ProductInfoList GetProducts();
        int DeleteProductById(int id);
        string CreateNewProduct(Product productToCreate);
        int UpdatePriceProductById(int id, float price);
    }
}
