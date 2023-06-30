using Domain.DomainEntities.CartEntities;
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
    public class CartsRepository : ICartRepository
    {
        private StreamWriter? _localDbRelPath;

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\FakeStore\\FakeStoreApi\\LocalFiles\\CartsData.json";

        public CartList GetAllCartsInfoFromUrl()
        {
            WebClient client = new WebClient();

            string CartsInfoAsString = client.DownloadString($"https://fakestoreapi.com/carts");

            List<CartData>? resultFromUrlAsDataEntitie = JsonConvert.DeserializeObject<List<CartData>>(CartsInfoAsString);

            CartList listOfCarts = new CartList
            {
                cartList = resultFromUrlAsDataEntitie.Select(propertyFromJson => new Cart
                {
                    Id = propertyFromJson.id,
                    IdUser = propertyFromJson.userId,
                    Date = propertyFromJson.date,
                    ProductsCartInfo = propertyFromJson.products.ToString(),
                }).ToList()
            };
            return listOfCarts;
        }

        public bool SaveCartsInFile(string list)
        {

            _localDbRelPath = new StreamWriter(_routeFile);

            _localDbRelPath.WriteLine(list);

            _localDbRelPath.Close();

            return true;
        }
    }
}
