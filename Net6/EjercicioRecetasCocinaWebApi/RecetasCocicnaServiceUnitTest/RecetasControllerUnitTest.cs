using Contracts.DomainEntitites;
using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RecetasCocinaWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioRecetasCocinaWebApiUnitTest
{
    public class RecetasControllerUnitTest
    {
        private readonly Mock<IRecetasCocinaService> _recetasCocinaService;
        private readonly Mock<ILogger<RecetasController>> _logger;

        private readonly RecetasController _recetasController;
        public RecetasControllerUnitTest()
        {
            _recetasCocinaService = new Mock<IRecetasCocinaService>();
            _logger = new Mock<ILogger<RecetasController>>();

            _recetasController = new RecetasController(_recetasCocinaService.Object, _logger.Object);
        }

        [Fact]
        public void Assert_True_When_GetRecipeCostByRecipeName()
        {
            //Arrange 
            CosteTotal coste = new CosteTotal { PrecioTotal = 10 };
            string recipeName = "tortilla";
            _recetasCocinaService.Setup(x => x.GetRecipeByName(recipeName)).Returns(coste);
            var expectedResult = 200;
            var expectedMessage = $"La receta con nombre {recipeName} cuesta {Math.Round(coste.PrecioTotal,2)}€";

            //Act

            var actionResult = _recetasController.GetRecipeCostByRecipeName(recipeName);

            ObjectResult response = actionResult as ObjectResult;
            //Assert

            Assert.Equal(expectedResult, response.StatusCode);
            Assert.True(response.Value.Equals(expectedMessage));

        }
    }
}
