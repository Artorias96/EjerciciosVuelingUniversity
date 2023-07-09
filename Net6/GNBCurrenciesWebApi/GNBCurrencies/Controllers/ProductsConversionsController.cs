using DomainContracts.DomainEntities;
using DomainContracts.ServiceContracts;
using GNBCurrencies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GNBCurrencies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsConversionsController : ControllerBase
    {
        private readonly ILogger<ProductsConversionsController> _logger;
        private readonly IProductsConversionsService _productsConversionsService;

        public ProductsConversionsController(ILogger<ProductsConversionsController> logger, IProductsConversionsService productsConversionsService)
        {
            _logger = logger;
            _productsConversionsService = productsConversionsService;
        }
        /// <summary>
        /// Take The Products with selected Sku With Amount converter to EUR
        /// </summary>
        /// <param name="sku">Sku example: 'T2006'</param>
        /// <returns></returns>
        [HttpGet]
        public async Task <IActionResult> GetAllConversions([Required] string sku)
        {
            List<ProductsConversions> productsToShow = await _productsConversionsService.GetAllProductsConversions(sku);

            if (productsToShow == null)
            {
                return BadRequest($"product with sku {sku} was not found");
            }

            decimal totalCost = 0;

            List<ProductsConversionsModel> productsInfo = productsToShow.Select(dataFromJson => new ProductsConversionsModel
            {
                Amount = Convert.ToDecimal(dataFromJson.Amount, CultureInfo.InvariantCulture),
                Currency = dataFromJson.Currency,
                Sku = dataFromJson.Sku
            }).ToList();

            foreach(var item in productsInfo)
            {
                totalCost += item.Amount;
            }

            string conversionToJson = JsonConvert.SerializeObject(productsInfo);

            return Ok($"{conversionToJson}\nTotal Cost = {Math.Round(totalCost,2)}");
        }
    }
}
