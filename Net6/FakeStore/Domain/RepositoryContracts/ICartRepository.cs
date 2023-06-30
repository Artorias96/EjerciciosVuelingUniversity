using Domain.DomainEntities.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface ICartRepository
    {
        CartList GetAllCartsInfoFromUrl();
        bool SaveCartsInFile(string list);
    }
}
