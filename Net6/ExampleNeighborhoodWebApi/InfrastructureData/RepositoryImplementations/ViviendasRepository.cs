using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainContracts.ServiceContracts;
using InfrastructureData.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class ViviendasRepository : IViviendasRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public ViviendasRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:Viviendas").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:Viviendas").Value;

        }

        public async Task<List<Viviendas>> GetAll()
        {
            List<Viviendas> viviendas = new();
            List<ViviendasDTO> viviendasFromJson = await GetDataFromJson();
            viviendas = await MapToDomainEntity(viviendasFromJson);
            return viviendas;
        }

        private async Task<List<ViviendasDTO>> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage viviendasInfo = await httpClient.GetAsync($"{_url}");

            string? viviendasInfoAsString = await viviendasInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(viviendasInfoAsString))
            {
                return JsonSerializer.Deserialize<List<ViviendasDTO>>(viviendasInfoAsString) ?? new List<ViviendasDTO>();
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<List<ViviendasDTO>>(fileInfo) ?? new List<ViviendasDTO>();
        }

        private async Task<List<Viviendas>> MapToDomainEntity(List<ViviendasDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new Viviendas
            {
                Id = dataFromJson.Id,
                IdBarrio = dataFromJson.IdBarrio,
                M2 = dataFromJson.M2,
                Añadidos = dataFromJson.Añadidos
            }).ToList();
        }

        public void SaveViviendasInFile(List<Viviendas> listOfConversions)
        {
            string conversionToJson = JsonSerializer.Serialize(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
