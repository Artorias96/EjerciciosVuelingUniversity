using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Infrastructure.RepositoryImplementations
{
    public class CommonRepository
    {
        
        public async Task<DittoModel> repoMethod()
        {
            HttpClient httpClient = new HttpClient();
            //string result = await Task.Run(() => { return "hello"; });

            //Obtenemos los datos de la URL
            //Llamada asyncrona para obtener la informacion de una web
            HttpResponseMessage dittoInfo = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");

            //Serializa el contenido http y lo guarda en un string
            //Llamada asincrona para convertir el resultado que nos ha devuelto la web en un string 
            string dittoInfoAsString = await dittoInfo.Content.ReadAsStringAsync();


            //Deserializamos a el tipo de objeto que lo queremos convertir pasandole el string de la info
            DittoModel resultFromUrlAsDomain = JsonConvert.DeserializeObject<DittoModel>(dittoInfoAsString);

            

            return resultFromUrlAsDomain;
        }
    }
}
