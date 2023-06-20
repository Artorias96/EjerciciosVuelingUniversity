using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class PokeTypesRepository : IPokeTypesRepository
    {
        private readonly string _localDbRelPath;

        public PokeTypesRepository()
        {
            _localDbRelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "PokeApiData.txt");
        }
        public async Task<PokeTypeInfo> TypeSelectedMovesInfo(string nameType)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage typesInfo = await client.GetAsync($"https://pokeapi.co/api/v2/type/{nameType}");

            string typesInfoAsString = await typesInfo.Content.ReadAsStringAsync();

            PokeTypeDto resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeTypeDto>(typesInfoAsString);

            List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.url.TrimEnd('/').Split('/').Last()).ToList();

            List<string> pokeNames = resultFromUrlAsDto.pokemon.Select(pokemon => pokemon.pokemon.name).ToList();

            PokeTypeInfo pokeTypeSelectedInfoList = new PokeTypeInfo
            {
             movesTypeSelected = attackNames,
             pokeTypeSelected = pokeNames
            };

            return (pokeTypeSelectedInfoList);
        }

        public void SaveDataInFile(List<string> list)
        {

            string actualData = File.ReadAllText(_localDbRelPath);

            if (actualData != "")
            {
                list.Add(actualData);
            }

            File.WriteAllLines(_localDbRelPath, list);
        }
    }
}
