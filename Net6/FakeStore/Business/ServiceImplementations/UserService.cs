using Business.ServiceContracts;
using Domain.DomainEntities.ProductEntities;
using Domain.DomainEntities.UserEntities;
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
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly ILogger<UserService> _logger;
        private MemoryCacheEntryOptions cacheOptions;

        public UserService(IUsersRepository usersRepository, ICacheRepository cacheRepository, ILogger<UserService> logger)
        {
            _usersRepository = usersRepository;
            _cacheRepository = cacheRepository;
            _logger = logger;
            cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);

        }

        public UserList GetAllUsers()
        {
                // Antes de obtener los productos, verifica si hay una caché válida y la utiliza
                var cachedProductInfoList = _cacheRepository.GetCache<UserList>("productInfoListKey");
                if (cachedProductInfoList != null)
                {
                    _logger.LogInformation("Products retrieved from cache successfully");
                    return cachedProductInfoList;
                }

                UserList usersInfo = _usersRepository.GetAllUsers();

                string productsToJson = JsonConvert.SerializeObject(usersInfo.usersList);

                _usersRepository.SaveUsersInFile(productsToJson);


                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)).SetSlidingExpiration(TimeSpan.FromSeconds(20)).SetSize(1024);

                // Guarda los productos en la caché
                _cacheRepository.SetCache<UserList>("productInfoListKey", usersInfo, cacheOptions);

                return usersInfo;
            
        }
    }
}
