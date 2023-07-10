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
    public class PreciosRepository : IPreciosRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;


        public PreciosRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:Precios").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:Precios").Value;

        }

        public async Task<Precios> GetAll()
        {
            Precios viviendas = new();
            PreciosDTO viviendasFromJson = await GetDataFromJson();
            viviendas = await MapToDomainEntity(viviendasFromJson);
            return viviendas;
        }

        private async Task<PreciosDTO> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage viviendasInfo = await httpClient.GetAsync($"{_url}");

            string? viviendasInfoAsString = await viviendasInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(viviendasInfoAsString))
            {
                PreciosDTO preciosDTO = new PreciosDTO
                {
                    Añadidos = JsonSerializer.Deserialize<Dictionary<string, CondicionesCosteDTO>>(viviendasInfoAsString) ?? new Dictionary<string, CondicionesCosteDTO>()
                };
                return preciosDTO;
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonSerializer.Deserialize<PreciosDTO>(fileInfo) ?? new PreciosDTO ();
        }

        private async Task<Precios> MapToDomainEntity(PreciosDTO listFromJson)
        {
            Precios precios = new Precios();
            precios.Añadidos = new Dictionary<string, CondicionesCoste>();

            foreach (var dictionayElement in listFromJson.Añadidos)
            {
                CondicionesCoste condicionesCoste = new CondicionesCoste();
                condicionesCoste.PrecioM2 = dictionayElement.Value.PrecioM2;
                condicionesCoste.Precio = dictionayElement.Value.Precio;

                precios.Añadidos.Add(dictionayElement.Key, condicionesCoste);
            }

            return precios;
        }

        public void SavePreciosInFile(Precios listOfConversions)
        {
            string conversionToJson = JsonSerializer.Serialize(listOfConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
