using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IPokeService
    {
        Task<PokeTypeInfo> GetMovesAndPokesSelectedTypeInSpanish(string name);
        Task<List<string>> GetMovesTypeFyreInfoInSpanish();
        Task<List<string>> GetPokeNames();
        bool ValidateNotPokeTypeName(string str);
        //bool ValidateNotEmptyValue(string str);
    }
}
