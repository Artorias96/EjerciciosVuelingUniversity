using Contracts.DomainEntitites;
using Contracts.RepositoryContracts;
using InfrastructureData.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class PrecioCocinadoRepository : IPrecioCocinadoRepository
    {
        private readonly string _url;

        public PrecioCocinadoRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:PrecioCocinado").Value;
        }

        public PrecioCocinado GetPrecioCocinado()
        {
            PrecioCocinado precioCocinadoPorMinuto = new();
            PrecioCocinadoDTO precioCocinadoFromJson = GetDataFromJson();
            precioCocinadoPorMinuto = MapToDomainEntity(precioCocinadoFromJson);
            return precioCocinadoPorMinuto;
        }

        private PrecioCocinadoDTO GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<PrecioCocinadoDTO>(content) ?? new PrecioCocinadoDTO();
        }

        private PrecioCocinado MapToDomainEntity(PrecioCocinadoDTO priceFromJson)
        {
            PrecioCocinado precioCocinado = new PrecioCocinado
            {
                CostePorMinuto = priceFromJson.CostePorMinuto,
            };
            return precioCocinado;
        }
    }
}
