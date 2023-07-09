using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainContracts.ServiceContracts;
using DomainImplementations;
using Moq;

namespace GNBCurrenciesUnitTest
{
    public class ProductsConversionsServiceUnitTest
    {
        private readonly Mock<IProductsConversionsRepository> _productsConversionsRepositoryMock;
        private readonly Mock<IConversionsRepository> _conversionsRepositoryMock;

        private readonly IProductsConversionsService _productsConversionsServiceMock;

        public ProductsConversionsServiceUnitTest()
        {
            _productsConversionsRepositoryMock = new Mock<IProductsConversionsRepository>();
            _conversionsRepositoryMock = new Mock<IConversionsRepository>();

            _productsConversionsServiceMock = new ProductsConversionsService(_productsConversionsRepositoryMock.Object, _conversionsRepositoryMock.Object);
        }
        [Fact]
        public async void When_GetAllProductsConversions_Returns_CorrectResult()
        {
            // Arrange
            string sku = "123";
            List<ProductsConversions> productsConversionsList = new List<ProductsConversions>()
        {
            new ProductsConversions { Sku = sku, Currency = "USD", Amount = 10 },
            new ProductsConversions { Sku = sku, Currency = "GBP", Amount = 20 },
            new ProductsConversions { Sku = "456", Currency = "EUR", Amount = 30 }
        };
            List<Conversions> conversionsList = new List<Conversions>()
        {
            new Conversions { From = "USD", To = "EUR", rate = 0.9m },
            new Conversions { From = "GBP", To = "EUR", rate = 1.1m }
        };

            _productsConversionsRepositoryMock.Setup(mock => mock.GetAll()).ReturnsAsync(productsConversionsList);
            _conversionsRepositoryMock.Setup(mock => mock.GetAll()).ReturnsAsync(conversionsList);

            // Act
            List<ProductsConversions> result = await _productsConversionsServiceMock.GetAllProductsConversions(sku);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("EUR", result[0].Currency);
            Assert.Equal(9, result[0].Amount);
            Assert.Equal("EUR", result[1].Currency);
            Assert.Equal(22, result[1].Amount);
        }

        [Fact]
        public async void When_SkuIsNotCorrect_GetAllProductsConversions_Returns_Null()
        {
            //Arrange 
            List<ProductsConversions> result = new() { new ProductsConversions() { Amount = 10 * 0.736m, Currency = "EUR", Sku = "T2006" } };
            string sku = "T0000";
            _productsConversionsRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetProductConversion());
            _conversionsRepositoryMock.Setup(y => y.GetAll()).ReturnsAsync(GetConversion());


            //Act

            var actionResult = await _productsConversionsServiceMock.GetAllProductsConversions(sku);

            //Assert

            Assert.Empty(actionResult);

        }

        private static List<ProductsConversions> GetProductsExample()
        {
            return new List<ProductsConversions>()
            {
                new ProductsConversions { Sku = "123", Currency = "USD", Amount = 10 },
                new ProductsConversions { Sku = "456", Currency = "EUR", Amount = 30 }
            };
        }

        private List<ProductsConversions> GetProductConversion() => new List<ProductsConversions>() { new ProductsConversions() { Amount = 10, Currency = "USD", Sku = "T2006" } };
        private List<Conversions> GetConversion() => new List<Conversions>() { new Conversions() { From = "USD", To = "EUR", rate = 0.736M } };

    }
}