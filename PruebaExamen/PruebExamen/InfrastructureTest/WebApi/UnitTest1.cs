
using Domain.DomainEntitys;
using Domain.ServiceImplementations;
using InfrastructureData.RepositoryImplementations;
using Moq;
using SpatialCoordinates.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace InfrastructureTest.WebApi
{  
    public class UnitTest1
    {
        private CoordinatesRepository _repository;
        public UnitTest1()
        {
            _repository = new CoordinatesRepository();
        }

        [Fact]
        public void Register_InputValid_ReturnsOkResult()
        {
            //Arrange
            //CoordinatesController controler = new CoordinatesController(
            //    new CoordinateService(
            //        new CoordinatesRepository()
            //    )
            //    );
            
            //CoordinatesController controler = new CoordinatesController ();

            List<decimal> values = new List<decimal> { 0, 0, 0 };

            //Act
            //IHttpActionResult result = controler.Register(values);

            //Assert
            //Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetList_InputEmpty_ReturnElements()
        {
            //Arrange


            //Act
            List<string> result = _repository.GetList();
            //Assert

            Assert.NotNull(result);
        }
    }
}
