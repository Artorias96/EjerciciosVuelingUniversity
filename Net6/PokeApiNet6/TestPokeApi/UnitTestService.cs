using Business.CustomExceptions;
using Business.ServiceImplementations;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Moq;

namespace TestPokeApi
{
   
    public class UnitTestService
    {
        private Mock<IPokeMovesRepository> _pokeMoveRepositoryMock;
        private Mock<IPokeTypesRepository> _pokeTypesRepositoryMock;
        private Mock<IPokeTypeFyreRepository> _pokeTypeFyreRepositoryMock;

        private PokeService _pokeService;

        public UnitTestService()
        {
            _pokeService = new PokeService(_pokeMoveRepositoryMock.Object, _pokeTypesRepositoryMock.Object, _pokeTypeFyreRepositoryMock.Object);
        }

        [Fact]
        public async Task GetMovesTypeFyreInfoInSpanish_ReturnsCorrectResult()
        {
            var typeFyreInfo = new List<string> { "move1", "move2", "move3" };
            _pokeTypeFyreRepositoryMock.Setup(x => x.TypeFyreMoveInfo()).ReturnsAsync(typeFyreInfo);
            var moveLanguageInfo1 = new MoveLanguageInfoList();
            moveLanguageInfo1.SetMovementNameByLanguageId("es", "movimiento1");
            var moveLanguageInfo2 = new MoveLanguageInfoList();
            moveLanguageInfo2.SetMovementNameByLanguageId("es", "movimiento2");
            var moveLanguageInfo3 = new MoveLanguageInfoList();
            moveLanguageInfo3.SetMovementNameByLanguageId("es", "movimiento3");
            _pokeMoveRepositoryMock.SetupSequence(x => x.GetMovementsLanguageInfoByName(It.IsAny<string>()))
                .ReturnsAsync(moveLanguageInfo1)
                .ReturnsAsync(moveLanguageInfo2)
                .ReturnsAsync(moveLanguageInfo3);
            var expected = new List<string> { "movimiento1", "movimiento2", "movimiento3" };
            var result = await _pokeService.GetMovesTypeFyreInfoInSpanish();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetPokeNames_ReturnsCorrectResult()
        {
            var typeFyrePokeInfo = new List<string> { "pokemon1", "pokemon2", "pokemon3" };
            _pokeTypeFyreRepositoryMock.Setup(x => x.TypeFyrePokeInfo()).ReturnsAsync(typeFyrePokeInfo);
            var expected = new List<string> { "pokemon1", "pokemon2", "pokemon3" };
            var result = await _pokeService.GetPokeNames();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetMovesAndPokesSelectedTypeInSpanish_ReturnsCorrectResult()
        {
            var typeSelectedInfo = new PokeTypeInfo
            {
                pokeTypeSelected = new List<string> { "pokemon1", "pokemon2", "pokemon3" },
                movesTypeSelected = new List<string> { "move1", "move2", "move3" }
            };
            _pokeTypesRepositoryMock.Setup(x => x.TypeSelectedMovesInfo("grass")).ReturnsAsync(typeSelectedInfo);
            var moveLanguageInfo1 = new MoveLanguageInfoList();
            moveLanguageInfo1.SetMovementNameByLanguageId("es", "movimiento1");
            var moveLanguageInfo2 = new MoveLanguageInfoList();
            moveLanguageInfo2.SetMovementNameByLanguageId("es", "movimiento2");
            var moveLanguageInfo3 = new MoveLanguageInfoList();
            moveLanguageInfo3.SetMovementNameByLanguageId("es", "movimiento3");
            _pokeMoveRepositoryMock.SetupSequence(x => x.GetMovementsLanguageInfoByName(It.IsAny<string>()))
                .ReturnsAsync(moveLanguageInfo1)
                .ReturnsAsync(moveLanguageInfo2)
                .ReturnsAsync(moveLanguageInfo3);
            var expected = new PokeTypeInfo
            {
                pokeTypeSelected = new List<string> { "pokemon1", "pokemon2", "pokemon3" },
                movesTypeSelected = new List<string> { "movimiento1", "movimiento2", "movimiento3" }
            };
            var result = await _pokeService.GetMovesAndPokesSelectedTypeInSpanish("grass");
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetSelectedTypeMovesPokesInSelectedLanguage_ReturnsCorrectResult()
        {
            var typeSelectedInfo = new PokeTypeInfo
            {
                pokeTypeSelected = new List<string> { "pokemon1", "pokemon2", "pokemon3" },
                movesTypeSelected = new List<string> { "move1", "move2", "move3" }
            };
            _pokeTypesRepositoryMock.Setup(x => x.TypeSelectedMovesInfo("grass")).ReturnsAsync(typeSelectedInfo);
            var moveLanguageInfo1 = new MoveLanguageInfoList();
            moveLanguageInfo1.SetMovementNameByLanguageId("es", "movimiento1");
            var moveLanguageInfo2 = new MoveLanguageInfoList();
            moveLanguageInfo2.SetMovementNameByLanguageId("es", "movimiento2");
            var moveLanguageInfo3 = new MoveLanguageInfoList();
            moveLanguageInfo3.SetMovementNameByLanguageId("es", "movimiento3");
            _pokeMoveRepositoryMock.SetupSequence(x => x.GetMovementsLanguageInfoByName(It.IsAny<string>()))
                .ReturnsAsync(moveLanguageInfo1)
                .ReturnsAsync(moveLanguageInfo2)
                .ReturnsAsync(moveLanguageInfo3);
            var expected = new PokeTypeInfo
            {
                pokeTypeSelected = new List<string> { "pokemon1", "pokemon2", "pokemon3" },
                movesTypeSelected = new List<string> { "movimiento1", "movimiento2" }
            };
            var result = await _pokeService.GetSelectedTypeMovesPokesInSelectedLanguage("grass", "es", 2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidateCorrectPokeTypeName_ValidInput_ReturnsTrue()
        {
            var result = _pokeService.ValidateCorrectPokeTypeName("grass");
            Assert.True(result);
        }

        [Fact]
        public void ValidateCorrectPokeTypeName_InvalidInput_ThrowsException()
        {
            Assert.Throws<InvalidTypeNameException>(() => _pokeService.ValidateCorrectPokeTypeName("invalid"));
        }

        [Fact]
        public void ValidateCorrectLanguage_ValidInput_ReturnsTrue()
        {
            var result = _pokeService.ValidateCorrectLanguage("es");
            Assert.True(result);
        }

        [Fact]
        public void ValidateCorrectLanguage_ValidInput_ReturnsFalse()
        {
            var result = _pokeService.ValidateCorrectLanguage("caquita");
            Assert.False(result);
        }

        [Fact]
        public void ValidateCorrectLanguage_InvalidInput_ThrowsException()
        {
            Assert.Throws<InvalidLanguageException>(() => _pokeService.ValidateCorrectLanguage("invalid"));
        }

        [Fact]
        public void ValidateCorrectNumberOfPokes_ValidInput_ReturnsTrue()
        {
            var result = _pokeService.ValidateCorrectNumberOfPokes(5);
            Assert.True(result);
        }

        [Fact]
        public void ValidateCorrectNumberOfPokes_InvalidInput_ThrowsException()
        {
            Assert.Throws<InvalidNumberPokesException>(() => _pokeService.ValidateCorrectNumberOfPokes(0));
        }
    }
}