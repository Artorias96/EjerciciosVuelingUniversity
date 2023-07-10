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
    public class BarriosRepository : IBarriosRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public BarriosRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:Barrios").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:Barrios").Value;

        }

        public async Task<List<Barrios>> GetAll()
        {
            List<Barrios> barrios = new();
            List<BarriosDTO> barriosFromJson = await GetDataFromJson();
            barrios = await MapToDomainEntity(barriosFromJson);
            return barrios;
        }

        private async Task<List<BarriosDTO>> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage viviendasInfo = await httpClient.GetAsync($"{_url}");

            string? viviendasInfoAsString = await viviendasInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(viviendasInfoAsString))
            {
                return JsonSerializer.Deserialize<List<BarriosDTO>>(viviendasInfoAsString);
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<List<BarriosDTO>>(fileInfo);
        }

        private async Task<List<Barrios>> MapToDomainEntity(List<BarriosDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new Barrios
            {
                Id = dataFromJson.Id,
                Name = dataFromJson.Nombre,
                CosteM2 = dataFromJson.CosteM2,
            }).ToList();
        }

        public void SaveBarriosInFile(List<Barrios> listOfConversions)
        {
            string conversionToJson = JsonSerializer.Serialize(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
