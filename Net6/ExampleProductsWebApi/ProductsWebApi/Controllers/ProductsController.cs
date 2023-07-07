using Business.ServiceContracts;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        /// <summary>
        /// Get info from product in selected language
        /// </summary>
        /// <param name="language">Language Input format: 'AA' (example: 'FR')</param>
        /// <response code="200">List of Product in selected Language </response>
        [HttpGet]
        public IActionResult GetProductBySelectedLanguage([Required] string language)
        {
            if(!_productService.ValidateCorrectLanguage(language))
            {
                _logger.LogError("ERROR inserting language, the format was incorrect");
                return BadRequest("Error, Incorrect Language format. Example: 'ES'");
            }
            try
            {
                List<ProductByLanguageDTO> productsSelectedsByLanguage = _productService.GetAllProductsTranslationsByLanguage(language);

                if(productsSelectedsByLanguage == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,"Product not found");
                }
                return Ok(productsSelectedsByLanguage);

            }catch (Exception)
            {
                _logger.LogError("ERROR, Something was Wrong");
                return BadRequest();
            }
        }
    }
}
