using Business.ServiceContracts;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Newtonsoft.Json;

namespace Business.ServiceImplementations
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public ProductInfoList GetProducts()
        {
            ProductInfo productInfo =  _productsRepository.GetAllProductsInfo();

            string productsToJson = JsonConvert.SerializeObject(productInfo.productsInfo);

            _productsRepository.SaveDataInFile(productsToJson);

            ProductInfoList productsToShow = new ProductInfoList
            {
                productsInfoList = productInfo
            };

            return productsToShow;

        }

        public int DeleteProductById(int id)
        {
           string listWithProductDeleted =  _productsRepository.DeleteProductById(id);

            _productsRepository.SaveDataInFile(listWithProductDeleted);

            return id;

        }

        public string CreateNewProduct(Product productToCreate)
        {
            string listWithProductCreated = _productsRepository.CreateNewProduct(productToCreate);

            _productsRepository.SaveDataInFile(listWithProductCreated);

            return "Product Inserted Succesfully";
        }

        public int UpdatePriceProductById(int id, float price)
        {
            string listWithProductUpdated = _productsRepository.UpdateProductById(id, price);

            _productsRepository.SaveDataInFile(listWithProductUpdated);

            return id;

        }
    }
}
