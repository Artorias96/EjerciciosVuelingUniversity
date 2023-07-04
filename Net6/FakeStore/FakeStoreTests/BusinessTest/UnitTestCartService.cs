using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.DomainEntities.CartEntities;
using Domain.DomainEntities.ProductEntities;
using Domain.RepositoryContracts;
using InfrastructureData.RepositoryImplementations;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreTests.BusinessTest
{
    public class UnitTestCartService
    {
        private readonly Mock<ICartRepository> _cartRepositoryMock;
        private readonly Mock<IProductsRepository> _productsRepositoryMock;
        private readonly Mock<ICacheRepository> _cacheRepositoryMock;
        private readonly Mock<ILogger<CartService>> _loggerMock;

        private readonly ICartService _cartService;

        public UnitTestCartService()
        {
            _cartRepositoryMock = new Mock<ICartRepository>();
            _productsRepositoryMock = new Mock<IProductsRepository>();
            _cacheRepositoryMock = new Mock<ICacheRepository>();     
            _loggerMock = new Mock<ILogger<CartService>>();

            _cartService = new CartService(_cartRepositoryMock.Object, _cacheRepositoryMock.Object, _loggerMock.Object, _productsRepositoryMock.Object);
        }

        [Fact]

        public void When_GetCartPrice_Returns_NotNutll()
        {
            //Arrange
            Product product1 = new Product { id = 1, category = "", description = "", price = 10 };
            Product product2 = new Product { id = 2, category = "", description = "", price = 50 };
            Product product3 = new Product { id = 3, category = "", description = "", price = 100 };
            ProductsCart element1 = new ProductsCart { productId = 1, quantity = 4 };
            ProductsCart element2 = new ProductsCart { productId = 2, quantity = 2 };
            ProductsCart element3 = new ProductsCart { productId = 3, quantity = 3 };
            int idCart = 1;

            _cartRepositoryMock.Setup(x => x.GetCartById(idCart)).Returns(new Cart 
            {
                Id = idCart, 
                Date = DateTime.UtcNow, 
                IdUser = 1, 
                products = new ProductsCart[] 
                { 
                element1, element2, element3
                }
            });

            float total = 0;

            _productsRepositoryMock.Setup(x => x.SelectProductById(element1.productId)).Returns(product1);

            _productsRepositoryMock.Setup(x => x.SelectProductById(element2.productId)).Returns(product2);

            _productsRepositoryMock.Setup(x => x.SelectProductById(element3.productId)).Returns(product3);

            float amount1 = element1.quantity * product1.price;
            float amount2 = element2.quantity * product2.price;
            float amount3 = element3.quantity * product3.price;
            total += amount1;
            total += amount2;
            total += amount3;

            //Act

            var result = _cartService.GetPriceCart(idCart);
            //Asser

            Assert.NotNull(result);
            Assert.True(result == total);
        }
    }
}
