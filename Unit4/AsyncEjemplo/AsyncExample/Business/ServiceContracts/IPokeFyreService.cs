using Domain.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IPokeFyreService
    {
        Task<List<string>> GetTypeFyreInfoInSpanish();
    }
}
