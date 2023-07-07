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
    public class MusiciansRepository : IMusiciansRepository
    {
        private const string _url = "https://localhost:7021/resources/musicos.json";
        public MusicianList GetAll()
        {
            MusicianList result = new();

            List<MusicianInfoFromJson> listFromJson = GetDataFromJson();

            result.musicianList = MapToDomainEntity(listFromJson);

            return result;

        }

        private static List<MusicianInfoFromJson> GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonSerializer.Deserialize<List<MusicianInfoFromJson>>(content) ?? new List<MusicianInfoFromJson>();
        }

        private static List<MusiciansInfo> MapToDomainEntity(List<MusicianInfoFromJson> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new MusiciansInfo
            {
                Name = dataFromJson.Name,
                RoleList = dataFromJson.Roles.Split(',').Select(x => x.ToLower()).ToList()

            }).ToList();

        }
    }
}
