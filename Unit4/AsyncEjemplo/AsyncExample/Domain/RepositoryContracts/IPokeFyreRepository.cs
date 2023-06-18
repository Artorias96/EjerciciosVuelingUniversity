
using Domain.DomainEntities;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IPokeFyreRepository
    {
        Task<PokeFyre> TypeFyreInfo();
    }
}
