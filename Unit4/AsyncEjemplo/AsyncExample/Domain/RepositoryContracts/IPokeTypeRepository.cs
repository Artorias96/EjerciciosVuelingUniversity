
using Domain.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IPokeTypeRepository
    {
        Task<List<string>> TypeFyreInfo();
    }
}
