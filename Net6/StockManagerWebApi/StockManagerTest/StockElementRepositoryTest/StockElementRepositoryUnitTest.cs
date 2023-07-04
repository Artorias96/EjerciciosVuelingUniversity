using Crosscutting.CustomExceptions;
using Domain.DomainEntity;
using InfrastructureData.RepositoryImplementations;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerTest.StockElementRepositoryTest
{
    public class StockElementRepositoryUnitTest
    {
        private StockElementRepository _stockElementRepository;
        private Mock<ILogger<StockElementRepository>> _loggerMock;
        private const string _testFilePath = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\StockManagerWebApi\\StockWebApi\\LocalFiles\\StockElements.json";

        public StockElementRepositoryUnitTest()
        {
            _loggerMock = new Mock<ILogger<StockElementRepository>>();
            _stockElementRepository = new StockElementRepository(_loggerMock.Object);

            // Crear un archivo de prueba
            //File.Create(_testFilePath).Dispose();
        }

        [Fact]
        public void CreateNewElement_WhenElementDoesNotExist_AddElementAndReturnJsonString()
        {
            // Arrange
            var element = new StockElement { Clue = "000kkk", Name = "Test Element", Description = "test description" };

            // Act
            var result = _stockElementRepository.CreateNewElement(element);

            // Assert
            Assert.NotNull(result);
            Assert.True(element.Clue == "000kkk");
            File.Delete(_testFilePath);
        }

        [Fact]
        public void CreateNewElement_WhenElementExists_ShouldThrowAlreadyExistingElement()
        {
            // Arrange
            var element = new StockElement { Clue = "000kkk", Name = "Test Element" };
            _stockElementRepository.CreateNewElement(element);

            // Act & Assert
            Assert.Throws<AlreadyExistingElement>(() => _stockElementRepository.CreateNewElement(element));
            File.Delete(_testFilePath);
        }

        [Fact]
        public void GetElementByClue_WhenElementExists_ShouldReturnElement()
        {
            // Arrange
            var element = new StockElement { Clue = "test", Name = "Test Element" };
            _stockElementRepository.CreateNewElement(element);

            // Act
            var result = _stockElementRepository.GetElementByClue("test");

            // Assert
            Assert.NotNull(result);
            Assert.True(element.Clue == "test");
            File.Delete(_testFilePath);
        }

        [Fact]
        public void GetElementByClue_WhenElementDoesNotExist_ShouldThrowNotExistingElement()
        {
            // Act & Assert
            Assert.Throws<NotExistingElement>(() => _stockElementRepository.GetElementByClue("666plh"));
            File.Delete(_testFilePath);
        }

        //private int GetElementsCountFromFile()
        //{
        //    using (StreamReader file = new StreamReader(_testFilePath))
        //    {
        //        string fileContents = file.ReadToEnd();
        //        var elements = JsonConvert.DeserializeObject<List<StockElement>>(fileContents);
        //        return elements.Count;
        //    }
        //}
    }
}
