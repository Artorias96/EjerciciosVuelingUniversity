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
    public class PokeMoveRepository : IPokeMoveRepository
    {
        private const string moveUrlInfo = "https://pokeapi.co/api/v2/move";
        public async Task<MoveLanguageInfoList> GetMovementsLanguageInfoById(string idMove)
        {
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage moveLanguageFyreInfo = await httpClient.GetAsync($"{moveUrlInfo}/{idMove}");

            //Serializa el contenido http y lo guarda en un string
            string fyreMoveInfoAsString = await moveLanguageFyreInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeMoveDto resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeMoveDto>(fyreMoveInfoAsString);

            MoveLanguageInfoList moveLanguageInfoList = new MoveLanguageInfoList
            {
                MoveLanguageInfo = resultFromUrlAsDto.names.Select(nameFromJson => new MoveLanguageInfo
                {
                    LanguageName = nameFromJson.language.name,
                    MoveName = nameFromJson.name,

                }).ToList()

            };
            return moveLanguageInfoList;

        }
    }
}
