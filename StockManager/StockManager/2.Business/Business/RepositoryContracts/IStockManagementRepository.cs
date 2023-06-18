using Domain.EntitiesDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RepositoryContracts
{
    public interface IStockManagementRepository
    {
        void Insert(StockEntityDomain entity);

        List<StockEntityDomain> GetIds();
    }
}
