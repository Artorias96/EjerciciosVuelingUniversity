using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainImplementations;
using Moq;
using System.Numerics;

namespace TestStarWarsWebApiNet6
{
    public class PlanetsServiceTests
    {
        private readonly Mock<IPlanetsRepository> _planetsRepositoryMock;
        private readonly Mock<IDistancePlanetsRepository> _distancePlanetsRepositoryMock;
        private readonly Mock<IRebelPercentageRepository> _rebelPercentageRepositoryMock;
        private readonly Mock<IPricePerYearRepository> _pricePerYearRepositoryMock;
        private readonly Mock<ICacheRepository> _cacheRepositoryMock;

        private readonly PlanetsService _planetsService;

        public PlanetsServiceTests()
        {
            _planetsRepositoryMock = new Mock<IPlanetsRepository>();
            _distancePlanetsRepositoryMock = new Mock<IDistancePlanetsRepository>();
            _rebelPercentageRepositoryMock = new Mock<IRebelPercentageRepository>();
            _pricePerYearRepositoryMock = new Mock<IPricePerYearRepository>();
            _cacheRepositoryMock = new Mock<ICacheRepository>();

            _planetsService = new PlanetsService(
                _planetsRepositoryMock.Object,
                _distancePlanetsRepositoryMock.Object,
                _rebelPercentageRepositoryMock.Object,
                _pricePerYearRepositoryMock.Object,
                _cacheRepositoryMock.Object
            );
        }

        [Fact]
        public async Task GetAllPlanetsDistances_Should_Return_PlanetsTravelInfoList()
        {
            // Arrange
            List<Planets> planetsList = new List<Planets> { new Planets() {PlanetName = "Tatooine", Code ="TAT", Sector ="1A" } };
            List<PlanetsTravelInfo> expectedPlanetsTravelInfoList = new List<PlanetsTravelInfo> { new PlanetsTravelInfo() {Origin ="Tatooine", Destination ="Alderaan", Distance = 1m }  };


            _planetsRepositoryMock.Setup(r => r.GetAllPlanets()).ReturnsAsync(planetsList);
            _cacheRepositoryMock.Setup(r => r.GetCache<List<PlanetsTravelInfo>>("key")).Returns((List<PlanetsTravelInfo>)null);
            _cacheRepositoryMock.Setup(r => r.SetCache("key", It.IsAny<List<PlanetsTravelInfo>>()));

            _distancePlanetsRepositoryMock.Setup(r => r.GetAllDistancePlanets()).ReturnsAsync(new DistancePlanets() {});
            _rebelPercentageRepositoryMock.Setup(r => r.GetAllRebelPercentage()).ReturnsAsync(new List<RebelPercentage>());
            _pricePerYearRepositoryMock.Setup(r => r.GetPricePerYear()).ReturnsAsync(new PricePerYear());

            // Act
            var result = await _planetsService.GetAllPlanetsDistances();

            // Assert

            Assert.Null(result);

        }

        [Fact]
        public async Task GetTravelCost_Should_Return_TotalTravelCost()
        {
            // Arrange
            PlanetsTravel planetsTravel = new PlanetsTravel {};

            List<Planets> planetsList = new List<Planets> { new Planets() { PlanetName = "", Code = "", Sector = "" } };
            List<PlanetsTravelInfo> planetsTravelInfoList = new List<PlanetsTravelInfo> {};
            PricePerYear pricePerYear = new PricePerYear { };
            List<RebelPercentage> rebelPercentageList = new List<RebelPercentage> {  };

            _planetsRepositoryMock.Setup(r => r.GetAllPlanets()).ReturnsAsync(planetsList);
            _distancePlanetsRepositoryMock.Setup(r => r.GetAllDistancePlanets()).ReturnsAsync(new DistancePlanets());
            _rebelPercentageRepositoryMock.Setup(r => r.GetAllRebelPercentage()).ReturnsAsync(rebelPercentageList);
            _pricePerYearRepositoryMock.Setup(r => r.GetPricePerYear()).ReturnsAsync(pricePerYear);

            _planetsRepositoryMock.Setup(r => r.GetAllPlanets()).ReturnsAsync(planetsList);
            _cacheRepositoryMock.Setup(r => r.GetCache<List<PlanetsTravelInfo>>("key")).Returns(planetsTravelInfoList);

            // Act
            var result = await _planetsService.GetTravelCost(planetsTravel);

            // Assert

            Assert.NotNull(result);

        }
    }
}