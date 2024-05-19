using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using InfrastructureData.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class PlanetsRepository : IPlanetsRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public PlanetsRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:Planets").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:Planets").Value;
        }

        public async Task<List<Planets>> GetAllPlanets()
        {
            List<Planets> planets = MapToDomainEntity(await GetDataFromJson());
            return planets;
        }

        private async Task<List<PlanetsDTO>> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage planetsInfo = await httpClient.GetAsync($"{_url}");

            string? planetsInfoAsString = await planetsInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(planetsInfoAsString))
            {
                return JsonSerializer.Deserialize<List<PlanetsDTO>>(planetsInfoAsString) ?? new List<PlanetsDTO>();
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<List<PlanetsDTO>>(fileInfo) ?? new List<PlanetsDTO>();
        }

        private List<Planets> MapToDomainEntity(List<PlanetsDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new Planets
            {
                PlanetName = dataFromJson.PlanetName,
                Code = dataFromJson.Code,
                Sector = dataFromJson.Sector
            }).ToList();
        }

        public void SavePlanetsInFile(List<Planets> listOfConversions)
        {
            string conversionToJson = JsonSerializer.Serialize(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}

