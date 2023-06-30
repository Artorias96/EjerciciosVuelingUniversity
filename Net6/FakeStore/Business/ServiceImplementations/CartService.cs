using Business.ServiceContracts;
using Domain.DomainEntities.CartEntities;
using Domain.DomainEntities.ProductEntities;
using Domain.RepositoryContracts;
using InfrastructureData.RepositoryImplementations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceImplementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly ILogger<CartService> _logger;

        public CartService(ICartRepository cartRepository, ICacheRepository cacheRepository, ILogger<CartService> logger)
        {
            _cacheRepository = cacheRepository;
            _cartRepository = cartRepository;
            _logger = logger;
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
    }
}
