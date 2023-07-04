using Crosscutting.CustomExceptions;
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

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\FakeStore\\InfrastructureData\\LocalFiles\\CartsData.json";

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
                    products = (ProductsCart[])propertyFromJson.products.Select(x => new ProductsCart
                    {
                        productId = x.productId,
                        quantity = x.quantity
                    }).ToArray()
                }).ToList()
            };
            return listOfCarts;
        }

        public Cart GetCartById(int id)
        {
            StreamReader fileReaded = new StreamReader(_routeFile);

            string recepted = fileReaded.ReadToEnd();

            fileReaded.Close();

            List<CartData>? resultFromLocalFileAsDataEntitie = JsonConvert.DeserializeObject<List<CartData>>(recepted);

            CartData? cartSelected = resultFromLocalFileAsDataEntitie.FirstOrDefault(cart => cart.id == id);

            if (cartSelected == null)
            {
                throw new NotExistingProduct(Convert.ToString(id));
            }

            Cart cart = new Cart
            {
                Id = cartSelected.id,
                Date = cartSelected.date,
                IdUser = cartSelected.userId,
                products = cartSelected.products.Select(p => new ProductsCart
                {
                    productId = p.productId,
                    quantity = p.quantity
                }).ToArray(),
            };
            return (cart);
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
