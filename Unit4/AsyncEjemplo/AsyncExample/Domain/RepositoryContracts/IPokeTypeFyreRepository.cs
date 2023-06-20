
using Domain.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IPokeTypeFyreRepository
    {
        Task<List<string>> TypeFyreMoveInfo();

        Task<List<string>> TypeFyrePokeInfo();
    }
}
