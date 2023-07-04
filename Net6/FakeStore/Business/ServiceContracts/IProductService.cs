using Domain.DomainEntities.ProductEntities;

namespace Business.ServiceContracts
{
    public interface IProductService
    {
        ProductInfoList GetProducts();
        ProductInfoList GetActualProducts();
        int DeleteProductById(int id);
        string CreateNewProduct(Product productToCreate);
        int UpdatePriceProductById(int id, float price);
        Product SelectProductById(int id);
    }
}
