using Contracts.DomainEntitites;
using Contracts.RepositoryContracts;
using InfrastructureData.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class AlimentosRepository : IAlimentosRepository
    {
        private const string _url = "https://localhost:7053/resources/alimentos.json";
        public List<Alimentos> GetAll()
        {
            List<Alimentos> alimentos = new();
            List<AlimentosDTO> alimentosFromJson = GetDataFromJson();
            alimentos = MapToDomainEntity(alimentosFromJson);
            return alimentos;
        }

        private static List<AlimentosDTO> GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<List<AlimentosDTO>>(content) ?? new List<AlimentosDTO>();
        }

        private static List<Alimentos> MapToDomainEntity(List<AlimentosDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new Alimentos
            {
                Nombre = dataFromJson.Nombre,
                Precio = dataFromJson.Precio
            }).ToList();
        }


    }
}
