using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface ICacheRepository
    {
        List<T> GetCache<T>(string str);
        void SetCache<T>(string str, List<T> generic);
    }
}
