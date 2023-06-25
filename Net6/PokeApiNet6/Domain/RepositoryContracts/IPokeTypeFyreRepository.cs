using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IPokeTypeFyreRepository
    {
        Task<List<string>> TypeFyreMoveInfo();

        Task<List<string>> TypeFyrePokeInfo();
    }
}
