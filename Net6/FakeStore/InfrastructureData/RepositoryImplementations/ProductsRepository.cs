using Crosscutting.CustomExceptions;
using Domain.DomainEntities.ProductEntities;
using Domain.RepositoryContracts;
using InfrastructureData.DataEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class ProductsRepository : IProductsRepository
    {
        private StreamWriter? _localDbRelPath;

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\FakeStore\\FakeStoreApi\\LocalFiles\\ProductsData.json";
        public ProductList GetAllProductsInfo()
        {
            WebClient client = new WebClient();

            string productsInfoAsString = client.DownloadString($"https://fakestoreapi.com/products");


            List<ProductData>? resultFromUrlAsDataEntitie = JsonConvert.DeserializeObject<List<ProductData>>(productsInfoAsString);


            ProductList productInfoList = new ProductList
            {
                productsInfo = resultFromUrlAsDataEntitie.Select(propertyProductsFromJson => new Product
                {
                    id = propertyProductsFromJson.id,
                    category = propertyProductsFromJson.category,
                    description = propertyProductsFromJson.description,
                    price = propertyProductsFromJson.price

                }).ToList()
            };

            return (productInfoList);
        }

        public ProductList GetActualProductsList()
        {
            StreamReader fileReaded = new StreamReader(_routeFile);

            string recepted = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<ProductData>? resultFromLocalFileAsDataEntities = JsonConvert.DeserializeObject<List<ProductData>>(recepted);

            ProductList productInfoList = new ProductList
            {
                productsInfo = resultFromLocalFileAsDataEntities.Select(propertyFromJson => new Product
                {
                    id = propertyFromJson.id,
                    category = propertyFromJson.category,
                    description = propertyFromJson.description,
                    price = propertyFromJson.price

                }).ToList()
            };

            return productInfoList;

        }

        public string DeleteProductById(int id)
        {
            StreamReader fileReaded = new StreamReader(_routeFile);

            string recepted = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<ProductData>? resultFromLocalFileAsDataEntitie = JsonConvert.DeserializeObject<List<ProductData>>(recepted);

            ProductData? productDeleted = resultFromLocalFileAsDataEntitie.FirstOrDefault(product => product.id == id);

            if (productDeleted == null)
            {
                throw new NotExistingProduct(Convert.ToString(id));
            }
            else
            {
                resultFromLocalFileAsDataEntitie.Remove(productDeleted);
            }

            string productsToJson = JsonConvert.SerializeObject(resultFromLocalFileAsDataEntitie);

            return (productsToJson);
        }

        public string CreateNewProduct(Product productToCreate)
        {
            StreamReader fileReaded = new StreamReader(_routeFile);

            string recepted = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<ProductData>? resultFromLocalFileAsDataEntities = JsonConvert.DeserializeObject<List<ProductData>>(recepted);

            ProductData productCreated = new ProductData
            {
                id = productToCreate.id,
                category = productToCreate.category,
                description = productToCreate.description,
                price = productToCreate.price
            };

            if (resultFromLocalFileAsDataEntities.FirstOrDefault(productData => productData.id == productCreated.id) == null)
            {
                resultFromLocalFileAsDataEntities.Add(productCreated);
            }
            else
            {
                throw new AlreadyExistingProduct(Convert.ToString(productCreated.id));
            }

            string productsToJson = JsonConvert.SerializeObject(resultFromLocalFileAsDataEntities);

            return (productsToJson);
        }

        public string UpdateProductById(int id, float newPrice)
        {
            StreamReader fileReaded = new StreamReader(_routeFile);

            string recepted = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<ProductData>? resultFromLocalFileAsDataEntitie = JsonConvert.DeserializeObject<List<ProductData>>(recepted);

            ProductData? productToUpdate = resultFromLocalFileAsDataEntitie.FirstOrDefault(product => product.id == id);

            if (productToUpdate == null)
            {
                throw new NotExistingProduct(Convert.ToString(id));
            }
            else
            {
                productToUpdate.price = newPrice;
                //resultFromLocalFileAsDataEntitie.Add(productToUpdate);
            }

            string productsToJson = JsonConvert.SerializeObject(resultFromLocalFileAsDataEntitie);

            return (productsToJson);
        }

        public bool SaveProductsInFile(string list)
        {

            _localDbRelPath = new StreamWriter(_routeFile);

            _localDbRelPath.WriteLine(list);

            _localDbRelPath.Close();

            return true;
        }
    }
}
