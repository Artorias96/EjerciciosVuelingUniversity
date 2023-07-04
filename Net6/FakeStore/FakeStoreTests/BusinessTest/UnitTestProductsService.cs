using Business.ServiceContracts;
using Business.ServiceImplementations;
using Castle.Core.Logging;
using Domain.DomainEntities.ProductEntities;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

namespace FakeStoreTests.BusinessTest
{
    public class UnitTestProductsService
    {
        private readonly Mock<IProductsRepository> _productRepositoryMock;
        private readonly Mock<ICacheRepository> _cacheRepositoryMock;
        private readonly Mock<ILogger<ProductService>> _loggerMock;

        private readonly IProductService _productServiceTest;

        public UnitTestProductsService()
        {
            _cacheRepositoryMock = new Mock<ICacheRepository>();
            _loggerMock = new Mock<ILogger<ProductService>>();
            _productRepositoryMock = new Mock<IProductsRepository>();

            _productServiceTest = new ProductService(_productRepositoryMock.Object, _cacheRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void When_GetProducts_cachedProductInfoList_is_not_null()
        {
            //Arrange
            _cacheRepositoryMock.Setup(x => x.GetCache<ProductInfoList>(It.IsAny<string>())).Returns(GetCacheResult());

            //Act
            var result = _productServiceTest.GetProducts();

            //Assert

            Assert.NotNull(result);
            Assert.True(result.productsInfoList.productsInfo.First().id == 52);
            _cacheRepositoryMock.Verify(x => x.GetCache<ProductInfoList>(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void When_GetProducts_cachedProductInfoList_is_null_and_get_repository_products()
        {
            //Arrange
            _cacheRepositoryMock.Setup(x => x.GetCache<ProductInfoList>(It.IsAny<string>()));
            _productRepositoryMock.Setup(x => x.GetAllProductsInfo()).Returns(GetChorizo());
            _productRepositoryMock.Setup(x => x.SaveProductsInFile(It.IsAny<string>()));
            _cacheRepositoryMock.Setup(x => x.SetCache(It.IsAny<string>(), It.IsAny<ProductInfoList>(), It.IsAny<MemoryCacheEntryOptions>()));
            //Act
            var result = _productServiceTest.GetProducts();

            //Assert

            Assert.NotNull(result);
            Assert.True(result.productsInfoList.productsInfo.First().id == 1);
            Assert.True(result.productsInfoList.productsInfo.FirstOrDefault(x => x.id == 1).category == "jewelry");

            _cacheRepositoryMock.Verify(x => x.GetCache<ProductInfoList>(It.IsAny<string>()), Times.Once);
            _productRepositoryMock.Verify(x => x.GetAllProductsInfo(), Times.Once);

        }

        [Fact]
        public void When_DeleteProducts_Id_Is_Not_Null()
        {
            //string productsToJson = JsonConvert.SerializeObject();
            //Arrange
            _productRepositoryMock.Setup(x => x.DeleteProductById(1)).Returns("{}");
            _productRepositoryMock.Setup(x => x.SaveProductsInFile(It.IsAny<string>()));
            //Act
            var result = _productServiceTest.DeleteProductById(1);

            //Assert

            Assert.NotNull(result);
            Assert.True(result == 1);
            _productRepositoryMock.Verify(x => x.DeleteProductById(1), Times.Once);
            _productRepositoryMock.Verify(x => x.SaveProductsInFile("{}"), Times.Once);
        }

        [Fact]
        public void When_CreateProducts_Return_Ok()
        {
            Product product = new Product { category = "jewelry", description = "joya", id = 1, price = 30 };
            //Arrange
            _productRepositoryMock.Setup(x => x.CreateNewProduct(product)).Returns("{}");
            _productRepositoryMock.Setup(x => x.SaveProductsInFile(It.IsAny<string>()));
            //Act
            var result = _productServiceTest.CreateNewProduct(product);

            //Assert

            Assert.NotNull(result);
            Assert.True(result == "Product Inserted Succesfully");
            _productRepositoryMock.Verify(x => x.CreateNewProduct(product), Times.Once);
            _productRepositoryMock.Verify(x => x.SaveProductsInFile("{}"), Times.Once);
        }

        [Fact]
        public void When_UpdateProducts_Return_Ok()
        {
            //Arrange
            _productRepositoryMock.Setup(x => x.UpdateProductById(1, 10)).Returns("{}");
            _productRepositoryMock.Setup(x => x.SaveProductsInFile(It.IsAny<string>()));
            //Act
            var result = _productServiceTest.UpdatePriceProductById(1, 10);

            //Assert

            Assert.NotNull(result);
            Assert.True(result == 1);
            _productRepositoryMock.Verify(x => x.UpdateProductById(1, 10), Times.Once);
            _productRepositoryMock.Verify(x => x.SaveProductsInFile("{}"), Times.Once);
        }

        private ProductInfoList GetCacheResult() => new ProductInfoList() { productsInfoList = new ProductList() { productsInfo = new List<Product>() { new Product { id = 52 } } } };
        private ProductList GetChorizo(int i = 1) => new ProductList { productsInfo = new List<Product>() { new Product { category = "jewelry", description = "joya", id = i, price = 30 } } };
    }
}