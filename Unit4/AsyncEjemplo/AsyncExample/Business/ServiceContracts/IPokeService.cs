using Domain.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IPokeService
    {
        Task<List<string>> GetMovesTypeFyreInfoInSpanish();
        Task<List<string>> GetPokeNames();

        Task<PokeTypeInfo> GetMovesAndPokesSelectedTypeInSpanish(string name);
    }
}
