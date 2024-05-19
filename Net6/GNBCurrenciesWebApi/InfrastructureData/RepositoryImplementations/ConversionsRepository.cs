using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using InfrastructureData.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class ConversionsRepository : IConversionsRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;

        public ConversionsRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:Conversions").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:Conversions").Value;
        }

        public async Task <List<Conversions>> GetAll()
        {
            List<Conversions> conversions = new();
            //List<ConversionsDTO> conversionsFromJson = 
            conversions = MapToDomainEntity(await GetDataFromJson());
            return conversions;
        }

        private async Task <List<ConversionsDTO>> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage conversionsInfo = await httpClient.GetAsync($"{_url}");

            string? conversionsInfoAsString = await conversionsInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(conversionsInfoAsString))
            {
                return JsonConvert.DeserializeObject<List<ConversionsDTO>>(conversionsInfoAsString) ?? new List<ConversionsDTO>();
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonConvert.DeserializeObject<List<ConversionsDTO>>(fileInfo) ?? new List<ConversionsDTO>();

        }

        private List<Conversions> MapToDomainEntity(List<ConversionsDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new Conversions
            {
                From = dataFromJson.From,
                rate = Convert.ToDecimal(dataFromJson.rate, CultureInfo.InvariantCulture),
                To = dataFromJson.To
            }).ToList();
        }

        public void SaveConversionsInFile(List<Conversions> listOfConversions)
        {
            string conversionToJson = JsonConvert.SerializeObject(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
