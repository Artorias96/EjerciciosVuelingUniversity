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
    public class DistancePlanetsRepository : IDistancePlanetsRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public DistancePlanetsRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:DistancePlanets").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:DistancePlanets").Value;

        }

        public async Task<DistancePlanets> GetAllDistancePlanets()
        {
            DistancePlanets distancePlanets = MapToDomainEntity(await GetDataFromJson());
            return distancePlanets;
        }

        private async Task<DistancePlanetDTO> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage distancePlanetsInfo = await httpClient.GetAsync($"{_url}");

            string? distancePlanetsInfoAsString = await distancePlanetsInfo.Content.ReadAsStringAsync();

            
            if (!string.IsNullOrEmpty(distancePlanetsInfoAsString))
            {
                DistancePlanetDTO distancePlanetsDTO = new DistancePlanetDTO();
                {
                    distancePlanetsDTO.DistancePlanet = JsonSerializer.Deserialize<Dictionary<string, List<PlanetInfoDTO>>>(distancePlanetsInfoAsString) ?? new Dictionary<string, List<PlanetInfoDTO>>();
                };

                return distancePlanetsDTO;
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<DistancePlanetDTO>(fileInfo) ?? new DistancePlanetDTO();
        }

        private DistancePlanets MapToDomainEntity(DistancePlanetDTO objectFromJson)
        {
            var distancePlanets = new DistancePlanets();
            distancePlanets.Distances = new Dictionary<string, List<PlanetInfo>>();

            foreach (var keyValue in objectFromJson.DistancePlanet)
            {
                var planetInfos = new List<PlanetInfo>();

                foreach (var planetInfoDto in keyValue.Value)
                {
                    var planetInfo = new PlanetInfo();

                    planetInfo.Code = planetInfoDto.Code;
                    planetInfo.LunarYears = planetInfoDto.LunarYears;

                    planetInfos.Add(planetInfo);
                }

                distancePlanets.Distances.Add(keyValue.Key, planetInfos);
            }

            return distancePlanets;
        }

        public void SaveDistancePlanetsInFile(DistancePlanets listOfConversions)
        {
            string conversionToJson = JsonSerializer.Serialize(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
