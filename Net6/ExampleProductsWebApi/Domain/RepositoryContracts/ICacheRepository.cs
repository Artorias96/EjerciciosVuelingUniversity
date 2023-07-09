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
        List<T> GetCache<T>(string userName);
        void SetCache<T>(string userName, List<T> generic);
    }
}
