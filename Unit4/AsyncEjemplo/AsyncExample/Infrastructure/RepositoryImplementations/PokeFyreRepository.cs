using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace Infrastructure.RepositoryImplementations
{
    public class PokeFyreRepository : IPokeFyreRepository
    {
         
        public async Task<PokeFyre> TypeFyreInfo()
        {
            HttpClient httpClient = new HttpClient();
            //string result = await Task.Run(() => { return "hello"; });

            //Obtenemos los datos de la URL
            //Llamada asyncrona para obtener la informacion de una web
            HttpResponseMessage typeFyreInfo = await httpClient.GetAsync("https://pokeapi.co/api/v2/type/fire");

            //Serializa el contenido http y lo guarda en un string
            //Llamada asincrona para convertir el resultado que nos ha devuelto la web en un string 
            string fyreTypeInfoAsString = await typeFyreInfo.Content.ReadAsStringAsync();

            HttpResponseMessage typeFyreMoves = await httpClient.GetAsync("https://pokeapi.co/api/v2/type/10/");
            string typeFyreMovesAsString = await typeFyreMoves.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeFyreDto resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeFyreDto>(fyreTypeInfoAsString);

            Dictionary<string, PokeFyre> dic;

            var PokeFyre = new PokeFyre()
            {
                name = resultFromUrlAsDto.name,
                moves = fyreTypeInfoAsString
            };

            return PokeFyre;
            //return fyreTypeInfoAsString;
        }
    }
}
