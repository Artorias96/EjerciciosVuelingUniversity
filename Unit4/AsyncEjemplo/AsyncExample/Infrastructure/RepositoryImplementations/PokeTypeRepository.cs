using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Infrastructure.RepositoryImplementations
{
    public class PokeTypeRepository : IPokeTypeRepository
    {
         
        public async Task<List<string>> TypeFyreInfo()
        {
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage typeFyreInfo = await httpClient.GetAsync("https://pokeapi.co/api/v2/type/fire");

            //Serializa el contenido http y lo guarda en un string
            string fyreTypeInfoAsString = await typeFyreInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeFyreDto resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeFyreDto>(fyreTypeInfoAsString);

            List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.url.TrimEnd('/').Split('/').Last()).ToList();
            //List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.name).ToList();
            
            

            return attackNames;
            //return fyreTypeInfoAsString;
        }
    }
}
