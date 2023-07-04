using Business.DTOS;
using Business.ServiceContracts;
using Crosscutting.CustomExceptions;
using Domain.DomainEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockElementController : ControllerBase
    {
        private readonly IStockElementService _stockElementService;
        private readonly ILogger<StockElementController> _logger;

        public StockElementController(IStockElementService stockElementService, ILogger<StockElementController> logger)
        {
            _stockElementService = stockElementService;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetElementByClue")]
        public IActionResult GetElementByClue(string clue)
        {
            try
            {
                if (!_stockElementService.ValidateClueFormat(clue))
                {
                    _logger.LogError("ERROR on clue, incorrect format");
                    return BadRequest("ERROR, invalid format must be '000AAA'");
                }

                StockElementDto elementSelected = _stockElementService.GetElementByClue(clue);
                return Ok(elementSelected);

            }catch(NotExistingElement ex)
            {
                _logger.LogError("ERROR trying to search the element by clue, the element does not exist");
                return BadRequest($"Some ERROR happened on clue {ex.Message}, the element does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateStockElement")]
        public IActionResult CreateNewElement(StockElementDto stockElementDto)
        {
            try
            {
                if (!stockElementDto.ValidateName(stockElementDto.Name) || !stockElementDto.ValidateDescription(stockElementDto.Description))
                {
                    _logger.LogError("ERROR on name or description. Out of characters range");
                    return BadRequest("ERROR, only 100 characters for name and 200 for description");
                }

                if (!_stockElementService.ValidateClueFormat(stockElementDto.Clue))
                {
                    _logger.LogError("ERROR on clue, incorrect format");
                    return BadRequest("ERROR, invalid format must be '000AAA'");
                }

                StockElement elementToSave = new StockElement
                {
                    Clue = stockElementDto.Clue,
                    Description = stockElementDto.Description,
                    Name = stockElementDto.Name,
                };

                _stockElementService.CreateElement(elementToSave);
                return Ok("Element created succesfully");
            }
            catch (AlreadyExistingElement ex)
            {
                _logger.LogError("ERROR trying to save the element created, the clue for that element already exist");
                return BadRequest($"Some ERROR happened on clue {ex.Message}, the element already exist");
            }
            catch (Exception ex)
            {
                _logger.LogError("Some ERROR happened");
                return BadRequest($"Some ERROR happened {ex.Message}");
            }
        }
    }
}
