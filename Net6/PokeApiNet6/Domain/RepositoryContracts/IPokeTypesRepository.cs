using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IPokeTypesRepository
    {
        Task<PokeTypeInfo> TypeSelectedMovesInfo(string nameType);
        //void SaveDataInFile(List<string> list);
    }
}
