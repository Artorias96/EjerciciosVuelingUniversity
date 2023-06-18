using Domain.EntitiesDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IStockManagementService
    {
        string Register(StockEntityDomain entity);
    }
}
