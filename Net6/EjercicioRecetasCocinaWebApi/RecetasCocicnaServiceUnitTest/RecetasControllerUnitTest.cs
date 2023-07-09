using Contracts.DomainEntitites;
using Contracts.ServiceContracts;
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

        public RecetasControllerUnitTest()
        {
            _recetasCocinaService = new Mock<IRecetasCocinaService>();
            _logger = new Mock<ILogger<RecetasController>>();

            new RecetasController(_recetasCocinaService.Object, _logger.Object);
        }

        [Fact]
        public void Assert_True_When_GetRecipeCostByRecipeName()
        {
            //Arrange 
            string recipeName = "guiso de duende";
            _cacheRepositoryMock.Setup(x => x.GetCache<CosteTotal>(It.IsAny<string>())).Returns((CosteTotal)null);
            _alimentosRepositoryMock.Setup(x => x.GetAll()).Returns(GetChorizo());
            _precioCocinadoRepositoryMock.Setup(x => x.GetPrecioCocinado()).Returns(new PrecioCocinado() { CostePorMinuto = 1 });
            _recetasRepositoryMock.Setup(x => x.GetRecipeByName(recipeName)).Returns((Recetas)null);

            //Act

            CosteTotal coste = _recetasCocinaServiceMock.GetRecipeByName(recipeName);


            //Assert

            Assert.Null(coste);

        }
    }
}
