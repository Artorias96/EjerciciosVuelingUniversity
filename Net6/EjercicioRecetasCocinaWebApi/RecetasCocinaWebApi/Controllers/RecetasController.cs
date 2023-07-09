using Contracts.DomainEntitites;
using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecetasCocinaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetasCocinaService _recetasCocinaService;
        private readonly ILogger<RecetasController> _logger;

        public RecetasController(IRecetasCocinaService recetasCocinaService, ILogger<RecetasController> logger)
        {
            _recetasCocinaService = recetasCocinaService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetRecipeCostByRecipeName([Required] string recipeName)
        {
            CosteTotal result = _recetasCocinaService.GetRecipeByName(recipeName);
            if(result == null)
            {
                _logger.LogError("ERROR, the recipe with selected name wasn´t found");
                return StatusCode(404,"The name of the recipe was not found");
            }

            return Ok($"La receta con nombre {recipeName} cuesta {Math.Round(result.PrecioTotal,2)}€");
        }
    }
}
