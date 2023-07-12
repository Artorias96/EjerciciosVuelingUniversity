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
    public class RebelPercentageRepository : IRebelPercentageRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public RebelPercentageRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:RebelPercentage").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:RebelPercentage").Value;
        }

        public async Task<List<RebelPercentage>> GetAllRebelPercentage()
        {
            List<RebelPercentage> planets = MapToDomainEntity(await GetDataFromJson());
            return planets;
        }

        private async Task<List<RebelpercentageDTO>> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage planetsInfo = await httpClient.GetAsync($"{_url}");

            string? planetsInfoAsString = await planetsInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(planetsInfoAsString))
            {
                return JsonSerializer.Deserialize<List<RebelpercentageDTO>>(planetsInfoAsString) ?? new List<RebelpercentageDTO>();
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<List<RebelpercentageDTO>>(fileInfo) ?? new List<RebelpercentageDTO>();
        }

        private List<RebelPercentage> MapToDomainEntity(List<RebelpercentageDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new RebelPercentage
            {
                PlanetName = dataFromJson.PlanetName,
                RebelPercent = int.Parse(dataFromJson.RebelPercent)
            }).ToList();
        }

        public void SaveRebelPercentageInFile(List<RebelPercentage> listOfConversions)
        {
            string conversionToJson = JsonSerializer.Serialize(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
