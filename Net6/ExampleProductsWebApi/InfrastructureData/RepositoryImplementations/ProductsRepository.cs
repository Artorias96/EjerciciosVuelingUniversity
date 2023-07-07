using Domain.DomainEntities;
using Domain.RepositoryContracts;
using InfrastructureData.DataEntities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InfrastructureData.RepositoryImplementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ILogger<ProductsRepository> _logger;
        private const string _url = "https://localhost:7189/resources/products.json";
        private StreamWriter? _localDbRelPath;

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\ExampleProductsWebApi\\InfrastructureData\\LocalFiles\\ProductLocalFiles.json";
        public ProductsRepository(ILogger<ProductsRepository> logger)
        {
            _logger = logger;
        }
        public List<Products> GetAll()
        {
            List<Products> products = new ();
            List<ProductsFromJson> productsFromJson = GetDataFromJson();
            string productsToJson = JsonConvert.SerializeObject(productsFromJson);
            SaveProductsInFile(productsToJson);
            products = MapToDomainEntity(productsFromJson);
            return products;
        }

        public Products GetProductById(int id)
        {
            List<ProductsFromJson> productsFromJson = GetDataFromJson();
            ProductsFromJson productSelecte = new ProductsFromJson();
            productSelecte = productsFromJson.FirstOrDefault(product => product.Id == id);

            if (productSelecte == null)
            {
                _logger.LogError("ERROR, The Product selected by Id was not found in the Database");
                return new Products();
            }
            Products products = new Products
            {
                Id = id,
                Discontinued = productSelecte.Discontinued,
                Price = productSelecte.Price,
                Rate = productSelecte.Rate.ToString(),
            };
            return products;

        }
        private static List<ProductsFromJson> GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<List<ProductsFromJson>>(content) ?? new List<ProductsFromJson>();
        }

        private static List<Products> MapToDomainEntity(List<ProductsFromJson> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new Products
            {
                Id = dataFromJson.Id,
                Price = dataFromJson.Price,
                Rate = Convert.ToString(dataFromJson.Rate),
                Discontinued = dataFromJson.Discontinued,
            }).ToList();
        }

        private void SaveProductsInFile(string list)
        {

            _localDbRelPath = new StreamWriter(_routeFile);

            _localDbRelPath.WriteLine(list);

            _localDbRelPath.Close();

        }
    }
}
