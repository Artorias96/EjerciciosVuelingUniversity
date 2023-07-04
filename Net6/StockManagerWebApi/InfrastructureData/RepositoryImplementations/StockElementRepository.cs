using Crosscutting.CustomExceptions;
using Domain.DomainEntity;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InfrastructureData.RepositoryImplementations
{
    public class StockElementRepository : IStockElementRepository
    {
        private readonly ILogger<StockElementRepository> _logger;
        private StreamWriter? _localDbRelPath;

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\StockManagerWebApi\\StockWebApi\\LocalFiles\\StockElements.json";

        public StockElementRepository(ILogger<StockElementRepository> logger)
        {
            _logger = logger;
        }
        public string CreateNewElement(StockElement elementToSave)
        {

            List<StockElement>? resultFromLocalFileAsDataEntity = GetFileAsEntity();

            if (resultFromLocalFileAsDataEntity.FirstOrDefault(element => element.Clue == elementToSave.Clue) == null)
            {
                resultFromLocalFileAsDataEntity.Add(elementToSave);
                _logger.LogInformation("Element saved in LocalFiles successfully");

                string elementsToJson = JsonConvert.SerializeObject(resultFromLocalFileAsDataEntity);

                return (elementsToJson);
            }
            else
            {
                throw new AlreadyExistingElement(Convert.ToString(elementToSave.Clue));
            }
        }

        public StockElement GetElementByClue(string clue)
        {
            StreamReader fileReaded = new StreamReader(_routeFile);

            string fileAsString = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<StockElement>? resultFromFileAsEntity = JsonConvert.DeserializeObject<List<StockElement>>(fileAsString);

            StockElement elementSelected = resultFromFileAsEntity.FirstOrDefault(element => element.Clue == clue);

            if (elementSelected == null)
            {
                throw new NotExistingElement(clue);
            }

            _logger.LogInformation("Element selected by clue in LocalFiles found successfully");
            return elementSelected;

        }
        public bool SaveProductsInFile(string list)
        {
            _localDbRelPath = new StreamWriter(_routeFile);
            _localDbRelPath.WriteLine(list);
            _localDbRelPath.Close();
            return true;
        }

        private List<StockElement>? GetFileAsEntity()
        {
            StreamReader? fileReaded = new StreamReader(_routeFile);

            string? recepted = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<StockElement>? resultFromLocalFileAsData = JsonConvert.DeserializeObject<List<StockElement>>(recepted);
            return resultFromLocalFileAsData;
        }
    }
}
