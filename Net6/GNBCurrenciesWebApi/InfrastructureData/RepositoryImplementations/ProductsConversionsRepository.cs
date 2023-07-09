using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using InfrastructureData.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class ProductsConversionsRepository : IProductsConversionsRepository
    {
        private StreamWriter? _localDbRelPath;
        private readonly string _url;
        private readonly string _fileRoute;

        public ProductsConversionsRepository(IConfiguration cofiguration)
        {
            _url = cofiguration.GetSection("ApiCalls:ProductsConversions").Value;
            _fileRoute = cofiguration.GetSection("PathFiles:ProductsConversions").Value;
        }

        public async Task<List<ProductsConversions>> GetAll()
        {
            List<ProductsConversions> productsConversions = new();
            List<ProductsConversionsDTO> productsConversionsFromJson = await GetDataFromJson();
            productsConversions = await MapToDomainEntity(productsConversionsFromJson);
            return productsConversions;
        }

        private async Task<List<ProductsConversionsDTO>> GetDataFromJson()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage productsConversionsInfo = await httpClient.GetAsync($"{_url}");

            string? productsConversionsInfoAsString = await productsConversionsInfo.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(productsConversionsInfoAsString))
            {
                return JsonConvert.DeserializeObject<List<ProductsConversionsDTO>>(productsConversionsInfoAsString) ?? new List<ProductsConversionsDTO>();
            }

            string fileInfo = File.ReadAllText(_fileRoute);

            return JsonConvert.DeserializeObject<List<ProductsConversionsDTO>>(fileInfo) ?? new List<ProductsConversionsDTO>();
        }

        private async Task<List<ProductsConversions>> MapToDomainEntity(List<ProductsConversionsDTO> listFromJson)
        {

            return listFromJson.Select(dataFromJson => new ProductsConversions
            {
                Amount = Convert.ToDecimal(dataFromJson.Amount, CultureInfo.InvariantCulture),
                Currency = dataFromJson.Currency,
                Sku = dataFromJson.Sku
            }).ToList();
        }

        public void SaveProductsConversionsInFile(List<ProductsConversions> listProductsConversions)
        {
            string conversionToJson = JsonConvert.SerializeObject(listProductsConversions);

            _localDbRelPath = new StreamWriter(_fileRoute);

            _localDbRelPath.WriteLine(conversionToJson);

            _localDbRelPath.Close();

        }
    }
}
