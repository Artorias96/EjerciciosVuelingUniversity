using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainContracts.ServiceContracts;
using DomainImplementations;
using Moq;

namespace ExampleNeighborhoodWebApiUnitTest
{
    public class ViviendasServiceUnitTest
    {
        private readonly Mock<IViviendasRepository> _viviendasRepositoryMock;
        private readonly Mock<IBarriosRepository> _barriosRepositoryMock;
        private readonly Mock<IPreciosRepository> _preciosRepositoryMock;
        private readonly Mock<ICacheRepository> _cacheRepositoryMock;

        private readonly IViviendasService _viviendasServiceMock;

        public ViviendasServiceUnitTest()
        {
            _viviendasRepositoryMock = new Mock<IViviendasRepository>();
            _barriosRepositoryMock = new Mock<IBarriosRepository>();
            _preciosRepositoryMock = new Mock<IPreciosRepository>();
            _cacheRepositoryMock = new Mock<ICacheRepository>();

            _viviendasServiceMock = new ViviendasService(_preciosRepositoryMock.Object, _viviendasRepositoryMock.Object, _barriosRepositoryMock.Object,  _cacheRepositoryMock.Object); 
        }

        [Fact]
        public async void When_GetViviendaById_ReturnsCorrectResut()
        {
            //Arrange
            int id = 1;

            _viviendasRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetViviendas());
            _barriosRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetBarrios);
            _preciosRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetPrecio);

            //Act

            PrecioCasa result = await _viviendasServiceMock.GetViviendaById(id);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(2, result.PrecioTotal);

        }

        [Fact]
        public async void When_GetViviendaById_IdDoesNotExist_ReturnsNull()
        {
            //Arrange
            int id = 2;

            _viviendasRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetViviendas());
            _barriosRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetBarrios);
            _preciosRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(GetPrecio);

            //Act

            PrecioCasa result = await _viviendasServiceMock.GetViviendaById(id);

            //Assert

            Assert.Null(result);


        }

        private List<Viviendas> GetViviendas() => new List<Viviendas>() { new Viviendas() { Id = 1, IdBarrio = 1, M2 = 1, Añadidos = new Dictionary<string, decimal>() { { "Terraza", 1 } } } };
        private List<Barrios> GetBarrios() => new List<Barrios>() { new Barrios() { Id = 1, Name = "barrio1", CosteM2 = 1 } };
        private Precios GetPrecio()
        {
            Precios precios = new Precios();
            CondicionesCoste condiciones1 = new CondicionesCoste();
            condiciones1.PrecioM2 = 1m;
            condiciones1.Precio = 0;

            CondicionesCoste condiciones2 = new CondicionesCoste();
            condiciones2.PrecioM2 = 0;
            condiciones2.Precio = 10;

            precios.Añadidos = new Dictionary<string, CondicionesCoste>();
            precios.Añadidos.Add("Terraza", condiciones1);
            precios.Añadidos.Add("Elemento", condiciones2);
            return precios;
        }
    }
}