using Domain.DomainEntities;
using Domain.RepositoryContracts;
using InfrastructureData.DataEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class TranslationsRepository : ITranslationsRepository
    {
        private const string _url = "https://localhost:7189/resources/productstranslations.json";
        private StreamWriter? _localDbRelPath;

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\ExampleProductsWebApi\\InfrastructureData\\LocalFiles\\ProductsTranslationsLocalFiles.json";
        public List<ProductTranslations> GetAll()
        {
            List<ProductTranslations> products = new();
            List<ProductsTranslationsFromJson> productsFromJson = GetDataFromJson();
            string productsToJson = JsonConvert.SerializeObject(productsFromJson);
            SaveProductsTranslationsInFile(productsToJson);
            products = MapToDomainEntity(productsFromJson);
            return products;
        }

        private static List<ProductsTranslationsFromJson> GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new StreamReader(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<List<ProductsTranslationsFromJson>>(content) ?? new List<ProductsTranslationsFromJson>();
        }

        private static List<ProductTranslations> MapToDomainEntity(List<ProductsTranslationsFromJson> listFromJson)
        {
            List<ProductTranslations> result = new();

            foreach (var item in listFromJson)
            {
                ProductTranslations productTranslations = new ProductTranslations();
                productTranslations.IdProduct = item.IdProduct;
                productTranslations.Translations = item.Translations;

                result.Add(productTranslations);
            }
            return result;
        }
        private void SaveProductsTranslationsInFile(string list)
        {

            _localDbRelPath = new StreamWriter(_routeFile);

            _localDbRelPath.WriteLine(list);

            _localDbRelPath.Close();

        }
    }
}
