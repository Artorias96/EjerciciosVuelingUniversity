using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface ICacheRepository
    {
        T GetCache<T>(string str);
        void SetCache<T>(string str, T generic, MemoryCacheEntryOptions? options);
    }
}
