using Business.ServiceContracts;
using Domain.DomainEntities.CartEntities;
using Domain.DomainEntities.ProductEntities;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business.ServiceImplementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly ILogger<CartService> _logger;

        public CartService(ICartRepository cartRepository, ICacheRepository cacheRepository, ILogger<CartService> logger, IProductsRepository productsRepository)
        {
            _cacheRepository = cacheRepository;
            _cartRepository = cartRepository;
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public CartInfoList GetCarts()
        {
            // Antes de obtener los carros, verifica si hay una caché válida y la utiliza
            var cachedProductInfoList = _cacheRepository.GetCache<CartInfoList>("productInfoListKey");
            if (cachedProductInfoList != null)
            {
                _logger.LogInformation("Carts retrieved from cache successfully");
                return cachedProductInfoList;
            }
            CartList cartInfo = _cartRepository.GetAllCartsInfoFromUrl();

            string productsToJson = JsonConvert.SerializeObject(cartInfo.cartList);

            _cartRepository.SaveCartsInFile(productsToJson);

            CartInfoList productsToShow = new CartInfoList
            {
                cartInfoLists = cartInfo
            };

            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);

            // Guarda los carros en la caché
            _cacheRepository.SetCache<CartInfoList>("productInfoListKey", productsToShow, cacheOptions);

            return productsToShow;
        }

        public float GetPriceCart(int id)
        {
            Cart cartSelect = _cartRepository.GetCartById(id);
            float total = 0;
            foreach (var item in cartSelect.products)
            {
                Product productFromCart = _productsRepository.SelectProductById(item.productId);
                float amount = item.quantity * productFromCart.price;
                total += amount;
            }
            return total;
        }
    }
}
