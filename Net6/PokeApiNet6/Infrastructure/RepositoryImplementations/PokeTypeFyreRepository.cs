using Business.Dtos;
using Domain.RepositoryContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class PokeTypeFyreRepository : IPokeTypeFyreRepository
    {
        private const string urlPokeFyre = "https://pokeapi.co/api/v2/type/fire";

        public async Task<List<string>> TypeFyreMoveInfo()
        {
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage typeFyreInfo = await httpClient.GetAsync($"{urlPokeFyre}");

            //Serializa el contenido http y lo guarda en un string
            string fyreTypeInfoAsString = await typeFyreInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeTypeDataEntity resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeTypeDataEntity>(fyreTypeInfoAsString);

            List<string> attackName = resultFromUrlAsDto.moves.Select(movement => movement.name).ToList();

            return attackName;
            //return fyreTypeInfoAsString;
        }

        public async Task<List<string>> TypeFyrePokeInfo()
        {
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage typeFyrePokeInfo = await httpClient.GetAsync($"{urlPokeFyre}");

            //Serializa el contenido http y lo guarda en un string
            string fyreTypePokeInfoAsString = await typeFyrePokeInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeTypeDataEntity resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeTypeDataEntity>(fyreTypePokeInfoAsString);


            List<string> pokeNames = resultFromUrlAsDto.pokemon.Select(pokemon => pokemon.pokemon.name).ToList();

            return pokeNames;
            //return fyreTypeInfoAsString;
        }
    }
}
