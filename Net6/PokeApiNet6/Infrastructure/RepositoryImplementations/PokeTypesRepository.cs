using Business.Dtos;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Newtonsoft.Json;

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

            PokeTypeDataEntity? resultFromUrlAsDto = JsonConvert.DeserializeObject<PokeTypeDataEntity>(typesInfoAsString);

            List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.url.TrimEnd('/').Split('/').Last()).ToList();

            //List<string> attackNames = resultFromUrlAsDto.moves.Select(movement => movement.name).ToList();

            List<string> pokeNames = resultFromUrlAsDto.pokemon.Select(pokemon => pokemon.pokemon.name).ToList();

            PokeTypeInfo pokeTypeSelectedInfoList = new PokeTypeInfo
            {
                movesTypeSelected = attackNames,
                pokeTypeSelected = pokeNames
            };

            return (pokeTypeSelectedInfoList);
        }

        //public void SaveDataInFile(List<string> list)
        //{
        //    List<string> dbAsList = File.ReadAllLines(_localDbRelPath).ToList();

        //    //var listToJson = JsonConvert.SerializeObject(list);
        //    dbAsList.Add(list);
        
        //    File.WriteAllText(_localDbRelPath, dbAsList);
        //}
    }
}
