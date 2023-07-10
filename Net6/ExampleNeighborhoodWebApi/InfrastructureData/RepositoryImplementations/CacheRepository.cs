using DomainContracts.RepositoryContracts;
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

        public T GetCache<T>(string str)
        {
            var response = _memoryCache.Get(str);

            return (T)response;
        }


        public void SetCache<T>(string str, T generic)
        {
            _memoryCache.Set(str, generic);
        }
    }
}
