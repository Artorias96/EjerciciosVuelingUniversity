using Business.CustomExceptions;
using Business.ServiceContracts;
using Domain.DomainEntities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {
        private readonly ILogger<PokeController> _logger;
        private readonly IPokeService _pokeService;

        private string errorMsg = "Error trying to search data";
        public PokeController(IPokeService pokeFyreService, ILogger<PokeController> logger)
        {
            _pokeService = pokeFyreService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetTypeFyreMoves")]
        public async Task<IActionResult> FirstAttacksTypeFyre()
        {
            try
            {
                List<string> typeFyreMovesNames = await _pokeService.GetMovesTypeFyreInfoInSpanish();
                _logger.LogInformation("The information has been read successfully");
                return Ok(typeFyreMovesNames);
            }catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return (IActionResult)BadRequest($"Some error ocurred {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetTypeFyrePokesNames")]
        public async Task<IActionResult> FirstPokeNamesTypeFyre()
        {
            try
            {
                List<string> typeFyrePokeNames = await _pokeService.GetPokeNames();
                _logger.LogInformation("The information has been read successfully");
                return Ok(typeFyrePokeNames);
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return (IActionResult)BadRequest($"Some error ocurred {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GetPokeNamesAndPokeMovesBySelectedType")]
        public async Task<IActionResult> GetSelectedType(string str)
        {

            try
            {
                _pokeService.ValidateNotPokeTypeName(str);
                PokeTypeInfo typeSelectedInfo = await _pokeService.GetMovesAndPokesSelectedTypeInSpanish(str);
                _logger.LogInformation("The information has been inserted successfully");
                string typeSelectedInfoToJson = JsonConvert.SerializeObject(typeSelectedInfo);
                return Ok(typeSelectedInfoToJson);
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
    }
}
