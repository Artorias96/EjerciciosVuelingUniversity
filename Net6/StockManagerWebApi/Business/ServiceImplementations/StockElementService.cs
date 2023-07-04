using Business.DTOS;
using Business.ServiceContracts;
using Domain.DomainEntity;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text.RegularExpressions;

namespace Business.ServiceImplementations
{
    public class StockElementService : IStockElementService
    {
        private readonly IStockElementRepository _stockElementRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly ILogger<StockElementService> _logger;

        public StockElementService(IStockElementRepository stockElementRepository, ICacheRepository cacheRepository, ILogger<StockElementService> logger)
        {
            _stockElementRepository = stockElementRepository;
            _cacheRepository = cacheRepository;
            _logger = logger;
        }

        public void CreateElement(StockElement stockElement)
        {   
            string elementCreated = _stockElementRepository.CreateNewElement(stockElement);
            _stockElementRepository.SaveProductsInFile(elementCreated);
        }

        public StockElementDto GetElementByClue(string clue)
        {
            StockElementDto cacheSelectedElement = _cacheRepository.GetCache<StockElementDto>("selectedElementKey");
            if(cacheSelectedElement != null)
            {
                _logger.LogInformation("Element selected retrieved from cache succesfully");
                return cacheSelectedElement;
            }

            StockElement elementSelected = _stockElementRepository.GetElementByClue(clue);

            StockElementDto selectedElementDto = new StockElementDto
            {
                Clue = elementSelected.Clue,
                Description = elementSelected.Description,
                Name = elementSelected.Name,
            };

            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);

            //Save the selected element in cache
            _cacheRepository.SetCache("selectedElementKey", selectedElementDto, cacheOptions);

            return selectedElementDto;
        }

        public bool ValidateClueFormat(string clue)
        {
            if (clue.Contains("ñ"))
            {
                return false;
            }

            string validateString = "^[0-9]{3}[A-Za-z]{3}$";

            if (Regex.IsMatch(clue, validateString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
