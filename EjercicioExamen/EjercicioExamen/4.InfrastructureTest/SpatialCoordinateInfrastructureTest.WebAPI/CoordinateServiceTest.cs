using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ServiceImplementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpatialCoordinateInfrastructureTest.WebAPI
{
    
    public class CoordinateServiceTest
    {
        private readonly ICoordinatesService _service;

        //Comprueba que la longitud de elemento en la lista es la correcta
        [Fact]
        public void When_GetList_ListLenghtValid()
        {
            var mock = new Mock<ICoordinatesService>();

            mock.Setup(x => x.GetList()).Returns(new List<string>() { "elber", "gadura"});

            Assert.True(mock.Object.GetList().Count == 2);
        }

        //comprueba que se realizo un registro usando el metodo insert y que devuelva true porque en efecto solo se invoca 1 vez
        [Fact]
        public void When_Register_ReturnsTrue()
        {
            var mock = new Mock<ICoordinatesRepository>();

            mock.Setup(x => x.Insert(new Domain.Coordinates())).Verifiable();

            var clastest = new CoordinatesService(mock.Object);

            clastest.Register(new Domain.Coordinates());

            Assert.True(mock.Invocations.Count == 1);
        }
        //public class TestSuiteColoursRgbController
        //{
        //    private readonly Mock<IRgbColourService> _colourService; // ESTO TENDRIA QUE SER EL INTERFAZ DEL REPO 
        //    private readonly MockFactory _mockFactory; // ASI TAL CUAL 

        //    public TestSuiteColoursRgbController()
        //    {
        //        _mockFactory = new MockFactory();
        //        _colourService = _mockFactory.CreateMock<IRgbColourService>();

        //    }

        //    [Fact]
            //public void TestEntryWithInvalidNameColour_Expects_Exception()
            //{

            //    RgbColourController rgbColourController = new RgbColourController(_colourService.MockObject); // LE PASAS AL SERVICIO QUE QUIERES TESTEAR LA INTERFAZ 

            //    RgbColour rgbColourWrong = new RgbColour
            //    {
            //        ColourName = "Papaya",
            //        PercentColour = 100,
            //        CoulourPalette = "MyCustomPapaya"

            //    }; // OBJETO QUE ESPERA EL REPO 

            //    RgbColourModel model = new RgbColourModel
            //    {
            //        IntroducedColourData = new List<string>()
            //    }; // OBJETO QUE PIDE EL METODO A TESTEAR 

            //    bool thrown = false;

            //    try
            //    {
            //        _colourService.Expects.AtLeastOne.Method(e => e.AddColour(rgbColourWrong)).WithAnyArguments().WillReturn();   // RETORNA EL VALOR QUE QUIERAS

            //        var sut = rgbColourController; // COGER SERVICIO 

            //        var response = sut.ColourIntroduced(model); // LLAMAS AL METODO QUE QUIERES TEST 

            //    }
            //    catch (NotAllowColourException)
            //    {
            //        thrown = true;
            //    }

            //    Assert.True(thrown); // AQUI EL EQUALS O LO QUE SEA ESPERADO

            }
}
