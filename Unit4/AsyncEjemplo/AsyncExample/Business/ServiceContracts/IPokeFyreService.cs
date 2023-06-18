using Domain.DomainEntities;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IPokeFyreService
    {
        Task<PokeFyre> GetTypeFyreInfo();
    }
}
