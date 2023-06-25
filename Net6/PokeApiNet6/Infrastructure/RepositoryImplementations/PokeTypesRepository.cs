using Business.Dtos;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Newtonsoft.Json;

namespace Infrastructure.RepositoryImplementations
{
    public class PokeTypesRepository : IPokeTypesRepository
    {
        private StreamWriter _localDbRelPath;
        private string routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\PokeApiNet6\\PokeApi\\LocalFiles\\PokeApiData.txt";

        public PokeTypesRepository()
        {
            _localDbRelPath = new StreamWriter(routeFile);
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
        public void SaveDataInFile(string list)
        {

            _localDbRelPath.WriteLine(list);
            _localDbRelPath.NewLine = "\n";
            _localDbRelPath.Close();
        }
    }
}
