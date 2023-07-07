using Domain.Agregates;
using Domain.DomainEntities;
using InfrastructureData.DataEntities;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class UnavaiableDaysRepository : IUnavaiableDaysRepository
    {
        private const string _url = "https://localhost:7021/resources/diasocupados.json";
        public UnavaiableDaysList GetAll()
        {
            UnavaiableDaysList result = new();

            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);

            using var reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            List<UnavailableDaysInfoFromJson> listFromJson = JsonSerializer.Deserialize<List<UnavailableDaysInfoFromJson>>(content) ?? new List<UnavailableDaysInfoFromJson>();

            result.List = listFromJson.Select(dataFromJson => new UnavaiableDaysInfo
            {
                Name = dataFromJson.Name,
                UnavaiableDays = dataFromJson.UnavaiableDays.Select(dateAsString => DateTime.ParseExact(dateAsString, "yyyyMMdd", null, DateTimeStyles.None)).ToList()

            }).ToList();

            return result;
        }
    }
}
