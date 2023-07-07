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
    public class PeopleNeedForMeetingRepository : IPeopleNeedForMeetingRepository
    {
        private const string _url = "https://localhost:7021/resources/20230630_Concierto_fin_curso_2023.json";
        public MusicianNeedForInfoList GetAll()
        {
            MusicianNeedForInfoList result = new();

            Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> listFromJson = GetDataFromJson();

            result.List = MapToDomainEntity(listFromJson);

            return result;

        }
        private static Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonSerializer.Deserialize<Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>>>(content) ??
                new Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>>();
        }

        private static List<MusicianNeedForMeetingInfo> MapToDomainEntity(Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> dictionaryFromJson)
        {
            List<MusicianNeedForMeetingInfo> result = new();

            foreach (var musicianNeedForMeetingInfo in dictionaryFromJson)
            {
                foreach (MusicianNeedForMeetingInfoFromJson need in musicianNeedForMeetingInfo.Value)
                {
                    result.Add(new MusicianNeedForMeetingInfo
                    {
                        Amount = need.Amount,
                        Category = need.Role.ToLower(),
                    });
                }
            }

            return result;
        }

    }
}

