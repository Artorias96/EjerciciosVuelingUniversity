using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using InfrastructureData.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class PricePerYearRepository : IPricePerYearRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public PricePerYearRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:PricePerYear").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:PricePerYear").Value;

        }

        public async Task <PricePerYear> GetPricePerYear()
        {

            PricePerYear pricePerYear = MapToDomainEntity(await GetDataFromJson());

            return pricePerYear;
        }

        private async Task <PricePerYearDTO> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage prieceForLunarYearInfo = await httpClient.GetAsync($"{_url}");

            string? prieceForLunarYearInfoAsString = await prieceForLunarYearInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(prieceForLunarYearInfoAsString))
            {
                return JsonSerializer.Deserialize<PricePerYearDTO>(prieceForLunarYearInfoAsString) ?? new PricePerYearDTO();
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<PricePerYearDTO>(fileInfo) ?? new PricePerYearDTO();
        }

        private PricePerYear MapToDomainEntity(PricePerYearDTO listFromJson)
        {
            PricePerYear prieceForLunarYear = new PricePerYear
            {
                PrieceForLunarYear = listFromJson.PrieceForLunarYear,
            };
            return prieceForLunarYear;
        }

        public void SavePricePerYearInFile(PricePerYear pricePerYear)
        {
            string pricePerYearToJson = JsonSerializer.Serialize(pricePerYear);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(pricePerYearToJson);

            _localDbRelPath.Close();

        }
    }
}
