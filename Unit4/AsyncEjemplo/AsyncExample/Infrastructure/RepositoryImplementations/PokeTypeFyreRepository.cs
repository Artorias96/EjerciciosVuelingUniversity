using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Infrastructure.RepositoryImplementations
{
    public class PokeTypeFyreRepository : IPokeTypeFyreRepository
    {
        private const string urlPokeFyre = "https://pokeapi.co/api/v2/type/fire";

        private readonly string _localDbRelPath;

        public PokeTypeFyreRepository()
        {
            _localDbRelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "PokeApiData.txt");
        }
        public async Task<List<string>> TypeFyreMoveInfo()
        {
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage typeFyreInfo = await httpClient.GetAsync($"{urlPokeFyre}");

            //Serializa el contenido http y lo guarda en un string
            string fyreTypeInfoAsString = await typeFyreInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeTypeDto resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeTypeDto>(fyreTypeInfoAsString);

            List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.url.TrimEnd('/').Split('/').Last()).ToList();
            //List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.name).ToList();
            List<string> pokeNames = resultFromUrlAsDto.pokemon.Select(pokemon => pokemon.pokemon.name).ToList();

            

            return attackNames;
            //return fyreTypeInfoAsString;
        }

        public async Task<List<string>> TypeFyrePokeInfo()
        {
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage typeFyrePokeInfo = await httpClient.GetAsync($"{urlPokeFyre}");

            //Serializa el contenido http y lo guarda en un string
            string fyreTypePokeInfoAsString = await typeFyrePokeInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeTypeDto resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeTypeDto>(fyreTypePokeInfoAsString);


            List<string> pokeNames = resultFromUrlAsDto.pokemon.Select(pokemon => pokemon.pokemon.name).ToList();

            return pokeNames;
            //return fyreTypeInfoAsString;
        }
    }
}
