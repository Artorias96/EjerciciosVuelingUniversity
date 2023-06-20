using Domain;
using Domain.ServiceImplementations;
using Infrastructure.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SpatialCoordinateInfrastructureTest.WebAPI
{
    public class CoordinatesControllerTestSuite
    {

        private CoordinatesRepository _repository;
        public CoordinatesControllerTestSuite()
        {
            _repository = new CoordinatesRepository();
        }

        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CoordinatesService service = new CoordinatesService(
                new CoordinatesRepository()
            );

            Coordinates input = new Coordinates
            {
                Coord1 = 1,
                Coord2 = 1,
                Coord3 = 1
            };

            // Act
            var exception = Record.Exception(() => service.Register(input));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void GetListFromDB_InputEmpty_ReturnElements()
        {
            //Arrange

            //Act
            List<string> result = _repository.GetList();
            //Assert

            Assert.NotNull(result);
        }
    }
}

