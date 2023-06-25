using Business.Dtos;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class PokeMovesRepository : IPokeMovesRepository
    {
        private const string moveUrlInfo = "https://pokeapi.co/api/v2/move";
        public async Task<MoveLanguageInfoList> GetMovementsLanguageInfoByName(string nameMove)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage moveLanguageFyreInfo = await httpClient.GetAsync($"{moveUrlInfo}/{nameMove}");

            //Serializa el contenido http y lo guarda en un string
            string? fyreMoveInfoAsString = await moveLanguageFyreInfo.Content.ReadAsStringAsync();

            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            PokeMoveDataEntity? resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeMoveDataEntity>(fyreMoveInfoAsString);

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
