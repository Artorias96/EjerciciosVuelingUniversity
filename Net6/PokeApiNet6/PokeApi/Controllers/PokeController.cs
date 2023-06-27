using Business.CustomExceptions;
using Business.ServiceContracts;
using Domain.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PokeApi.Controllers
{
    /// <summary>
    /// This api handles all the logic for the PokeApi
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {
        private readonly ILogger<PokeController> _logger;
        private readonly IPokeService _pokeService;
        private readonly IMemoryCache _memoryCache;

        private string errorMsg = "Error trying to search data";

        public PokeController(IPokeService pokeFyreService, ILogger<PokeController> logger, IMemoryCache memoryCache)
        {
            _pokeService = pokeFyreService;
            _logger = logger;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// This method take the first 10 attack from the pokemon type fire
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTypeFyreMoves")]
        public async Task<IActionResult> FirstAttacksTypeFyre()
        {
            try
            {
                List<string> typeFyreMovesNames = await _pokeService.GetMovesTypeFyreInfoInSpanish();
                _logger.LogInformation("The information has been read successfully");
                return Ok(typeFyreMovesNames);
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return (IActionResult)BadRequest($"Some error ocurred {ex.Message}");
            }
        }
        /// <summary>
        /// Shows the first 10 pokemons from the pokemon type fire
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTypeFyrePokesNames")]
        public async Task<IActionResult> FirstPokeNamesTypeFyre()
        {
            try
            {
                List<string>? output = _memoryCache.Get<List<string>>("pokeFireNames");
                if (output is not null)
                {
                    _logger.LogInformation("The information has been retrieved successfully from cache");
                    return Ok(output);
                }
                _logger.LogInformation("The information has not been found in cache, service called");
                List<string> typeFyrePokeNames = await _pokeService.GetPokeNames();

                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);

                _memoryCache.Set("pokeFireNames", typeFyrePokeNames, cacheOptions);

                return Ok(typeFyrePokeNames);
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return (IActionResult)BadRequest($"Some error ocurred {ex.Message}");
            }
        }
        /// <summary>
        /// Show the first 10 movements and pokemon from the selected pokemon type
        /// </summary>
        /// <param name="pokeType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPokeNamesAndPokeMovesBySelectedType")]
        public async Task<IActionResult> GetSelectedType(string pokeType)
        {
            try
            {
                string? output = _memoryCache.Get<string>(pokeType);
                // Si existe información en la caché para el tipo de Pokémon seleccionado, devolver esa información
                if (output is not null)
                {
                    _logger.LogInformation("The information has been retrieved successfully from cache");
                    return Ok(output);
                }
                // Si no existe información en la caché para el tipo de Pokémon seleccionado,
                // llamar al servicio para obtener la información actualizada y guardarla en la caché
                else
                {
                    _logger.LogInformation("The information has not been found in cache, service called");
                    _pokeService.ValidateCorrectPokeTypeName(pokeType);
                    PokeTypeInfo typeSelectedInfo = await _pokeService.GetMovesAndPokesSelectedTypeInSpanish(pokeType);

                    string typeSelectedInfoToJson = JsonConvert.SerializeObject(typeSelectedInfo);
                    var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);


                    _memoryCache.Set(pokeType, typeSelectedInfoToJson, cacheOptions);


                    return Ok(typeSelectedInfoToJson);
                }
            }
            catch (InvalidTypeNameException ex)
            {
                _logger.LogError("Error inserted name for pokemon type, the name is not a pokemon type name");
                return BadRequest($"Some problem found on {ex.Message}, the name inserted is not a pokemon type name");
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return (IActionResult)BadRequest($"Some error ocurred {ex.Message}");
            }
        }
        /// <summary>
        /// Select the pokemon type, language and amount of pokemons witch you want the information
        /// </summary>
        /// <param name="pokeType"></param>
        /// <param name="language"></param>
        /// <param name="numberPokes"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPokeNamesAndPokeMovesBySelectedTypeAndLanguage")]
        public async Task<IActionResult> GetSelectedTypeLanguageAndNumberOfPoke(string pokeType, string language, int numberPokes)
        {
            try
            {
                _pokeService.ValidateCorrectPokeTypeName(pokeType);
                _pokeService.ValidateCorrectLanguage(language);
                _pokeService.ValidateCorrectNumberOfPokes(numberPokes);

                PokeTypeInfo typeSelectedInfo = await _pokeService.GetSelectedTypeMovesPokesInSelectedLanguage(pokeType, language, numberPokes);
                _logger.LogInformation("The information has been inserted successfully");

                string typeSelectedInfoToJson = JsonConvert.SerializeObject(typeSelectedInfo);
                return Ok(typeSelectedInfoToJson);
            }
            catch (InvalidTypeNameException ex)
            {
                _logger.LogError("Error inserted name for pokemon type, the name is not a pokemon type name");
                return BadRequest($"Some problem found on {ex.Message}, the name inserted is not a pokemon type name");
            }
            catch (InvalidLanguageException ex)
            {
                _logger.LogError("Error inserted language for pokemon type, the name is not a reference for a real language");
                return BadRequest($"Some problem found on {ex.Message}, the language inserted does not exist");
            }
            catch (InvalidNumberPokesException ex)
            {
                _logger.LogError("Error inserted number for pokemon you want to see, the number was 0 or pass 20");
                return BadRequest($"Some problem found on {ex.Message}, the number of pokemons inserted can´t be 0 or pass 20");
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return (IActionResult)BadRequest($"Some error ocurred {ex.Message}");
            }
        }
    }
}
