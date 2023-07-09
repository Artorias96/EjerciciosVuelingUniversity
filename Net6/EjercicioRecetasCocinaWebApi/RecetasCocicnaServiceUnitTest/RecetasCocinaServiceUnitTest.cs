using Contracts.DomainEntitites;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;
using Implementations;
using Moq;

namespace RecetasCocicnaServiceUnitTest
{
    public class RecetasCocinaServiceUnitTest
    {
        private readonly Mock<IAlimentosRepository> _alimentosRepositoryMock;
        private readonly Mock<IPrecioCocinadoRepository> _precioCocinadoRepositoryMock;
        private readonly Mock<IRecetasRepository> _recetasRepositoryMock;
        private readonly Mock<ICacheRepository> _cacheRepositoryMock;

        private readonly IRecetasCocinaService _recetasCocinaServiceMock;

        public RecetasCocinaServiceUnitTest()
        {
            _alimentosRepositoryMock = new Mock<IAlimentosRepository>();
            _precioCocinadoRepositoryMock = new Mock<IPrecioCocinadoRepository>();
            _recetasRepositoryMock = new Mock<IRecetasRepository>();
            _cacheRepositoryMock = new Mock<ICacheRepository>();

            _recetasCocinaServiceMock = new RecetasCocinaService(_alimentosRepositoryMock.Object, _precioCocinadoRepositoryMock.Object, _recetasRepositoryMock.Object, _cacheRepositoryMock.Object);
        }
        [Fact]
        public void Assert_Null_WhenCacheIsNull_And_RecipeNotFound()
        {
            //Arrange 
            string recipeName = "guiso de duende";
            _cacheRepositoryMock.Setup(x => x.GetCache<CosteTotal>(It.IsAny<string>())).Returns((CosteTotal)null);
            _alimentosRepositoryMock.Setup(x => x.GetAll()).Returns(GetAlimento());
            _precioCocinadoRepositoryMock.Setup(x => x.GetPrecioCocinado()).Returns(new PrecioCocinado() { CostePorMinuto = 1 });
            _recetasRepositoryMock.Setup(x => x.GetRecipeByName(recipeName)).Returns((Recetas)null);

            //Act

            CosteTotal coste = _recetasCocinaServiceMock.GetRecipeByName(recipeName);


            //Assert

            Assert.Null(coste);

        }
        [Fact]
        public void Assert_True_WhenCacheIsNotNull()
        {
            //Arrange 

            CosteTotal costeTotal = new CosteTotal { PrecioTotal = 10 };
            _cacheRepositoryMock.Setup(x => x.GetCache<CosteTotal>(It.IsAny<string>())).Returns(costeTotal);

            //Act

            CosteTotal coste = _recetasCocinaServiceMock.GetRecipeByName(It.IsAny<string>());

            //Assert

            Assert.True(coste.PrecioTotal == costeTotal.PrecioTotal);

        }
        [Fact]
        public void Assert_True_WhenCacheIsNull_AndGetFromRepository_ReturnsCorrectResult()
        {
            //Arrange 
            string recipeName = "guiso de duende";
            _cacheRepositoryMock.Setup(x => x.GetCache<CosteTotal>(It.IsAny<string>())).Returns((CosteTotal)null);
            _alimentosRepositoryMock.Setup(x => x.GetAll()).Returns(GetAlimento());
            _precioCocinadoRepositoryMock.Setup(x => x.GetPrecioCocinado()).Returns(new PrecioCocinado() { CostePorMinuto = 0 });
            _recetasRepositoryMock.Setup(x => x.GetRecipeByName(recipeName)).Returns(GetRecipe());


            //Act

            CosteTotal coste = _recetasCocinaServiceMock.GetRecipeByName(recipeName);


            //Assert

            Assert.True(coste.PrecioTotal == 20);

        }

        private List<Alimentos> GetAlimento() => new List<Alimentos>() { new Alimentos() { Nombre = "huevo", Precio = 10 } };
        private Recetas GetRecipe() => new Recetas() { Nombre = "", Ingredientes = new Dictionary<string, decimal>() { { "huevo", 2 } }, MinutosCocinando = 0 };
    }
}