using Domain.Entities;
using Domain.ServiceImplementations;
using Infrastructure.RepositoryImplementations;
using System;
using System.Linq;
using Xunit;

namespace InfrastructureTest
{
    public class CarColorControllerTestSuite
    {
        private CarColorRepository _repository;
        public CarColorControllerTestSuite()
        {
            _repository = new CarColorRepository();
        }

        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CarColorService service = new CarColorService(
                new CarColorRepository()
            );

            CarColor input = new CarColor
            {
                colorCar = "Blue",
                percentage = 58,
                marca = "Volkswagen"
            };

            // Act
            var exception = Record.Exception(() => service.Register(input));

            // Assert
            Assert.NotNull(exception);
        }
    }
}
