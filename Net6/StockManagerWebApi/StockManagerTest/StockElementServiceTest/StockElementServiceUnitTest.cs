using Business.DTOS;
using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.DomainEntity;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;

namespace StockManagerTest.StockElementServiceTest
{
    public class StockElementServiceUnitTest
    {
        private readonly Mock<IStockElementRepository> _elementRepositoryMock;
        private readonly Mock<ICacheRepository> _cacheRepositoryMock;
        private readonly Mock<ILogger<StockElementService>> _loggerMock;

        private readonly IStockElementService _elementServiceTest;

        public StockElementServiceUnitTest()
        {
            _cacheRepositoryMock = new Mock<ICacheRepository>();
            _elementRepositoryMock = new Mock<IStockElementRepository>();
            _loggerMock = new Mock<ILogger<StockElementService>>();

            _elementServiceTest = new StockElementService(_elementRepositoryMock.Object, _cacheRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void When_CreateElement_VerifyInvocation()
        {
            //Arrange
            StockElement stockElement = new StockElement { Clue = "555HHH", Description = "description", Name = "name" };
            _elementRepositoryMock.Setup(x => x.CreateNewElement(stockElement)).Returns("stockCreated");
            _elementRepositoryMock.Setup(x => x.SaveProductsInFile("stockCreated"));
            //Act
            _elementServiceTest.CreateElement(stockElement);

            //Assert
            _elementRepositoryMock.Verify(x => x.CreateNewElement(stockElement), Times.Once);
            _elementRepositoryMock.Verify(x => x.SaveProductsInFile("stockCreated"), Times.Once);
        }

        [Fact]
        public void When_GetElementByClue_Cache_IsNull_GetRepositoryElement()
        {
            //Arrange
            _cacheRepositoryMock.Setup(x => x.GetCache<StockElementDto>(It.IsAny<string>()));
            _elementRepositoryMock.Setup(x => x.GetElementByClue("888BBB")).Returns(new StockElement { Clue = "888BBB", Description = "description", Name = "paco" });
            _cacheRepositoryMock.Setup(x => x.SetCache(It.IsAny<string>(), It.IsAny<StockElementDto>(), It.IsAny<MemoryCacheEntryOptions>()));
            //Act
            var result = _elementServiceTest.GetElementByClue("888BBB");
            //Assert
            Assert.NotNull(result);
            Assert.True(result.Clue == "888BBB");

        }
    }
}