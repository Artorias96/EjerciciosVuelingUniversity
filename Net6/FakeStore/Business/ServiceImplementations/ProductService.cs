using Business.ServiceContracts;
using Domain.DomainEntities.ProductEntities;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business.ServiceImplementations
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductsRepository productsRepository, ICacheRepository cacheRepository, ILogger<ProductService> logger)
        {
            _productsRepository = productsRepository;
            _cacheRepository = cacheRepository;
            _logger = logger;
        }
        public ProductInfoList GetProducts()
        {
            // Antes de obtener los productos, verifica si hay una caché válida y la utiliza
            var cachedProductInfoList = _cacheRepository.GetCache<ProductInfoList>("productInfoListKey");
            if (cachedProductInfoList != null)
            {
                _logger.LogInformation("Products retrieved from cache successfully");
                return cachedProductInfoList;
            }
            ProductList productInfo =  _productsRepository.GetAllProductsInfo();

            string productsToJson = JsonConvert.SerializeObject(productInfo.productsInfo);

            _productsRepository.SaveProductsInFile(productsToJson);

            ProductInfoList productsToShow = new ProductInfoList
            {
                productsInfoList = productInfo
            };

            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);

            // Guarda los productos en la caché
            _cacheRepository.SetCache<ProductInfoList>("productInfoListKey", productsToShow, cacheOptions);

            return productsToShow;
        }

        public int DeleteProductById(int id)
        {
           string listWithProductDeleted =  _productsRepository.DeleteProductById(id);

            _productsRepository.SaveProductsInFile(listWithProductDeleted);

            return id;

        }

        public ProductInfoList GetActualProducts()
        {
            ProductList actualList = _productsRepository.GetActualProductsList();

            ProductInfoList actualProductsToShow = new ProductInfoList
            {
                productsInfoList = actualList
            };

            return actualProductsToShow;
        }

        public string CreateNewProduct(Product productToCreate)
        {
            string listWithProductCreated = _productsRepository.CreateNewProduct(productToCreate);

            _productsRepository.SaveProductsInFile(listWithProductCreated);

            return "Product Inserted Succesfully";
        }

        public int UpdatePriceProductById(int id, float price)
        {
            string listWithProductUpdated = _productsRepository.UpdateProductById(id, price);

            _productsRepository.SaveProductsInFile(listWithProductUpdated);

            return id;

        }
    }
}
