using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _memoryCache;

        public CacheRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<T> GetCache<T>(string userName)
        {
            var response = _memoryCache.Get(userName);

            return (List<T>)response;
        }

        public void SetCache<T>(string userName, List<T> generic) // LE PONEMOS LA KEY QUE QUERAMOS 
        {
            _memoryCache.Set(userName, generic);
        }
    }
}
