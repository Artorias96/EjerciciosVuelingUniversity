using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.RepositoryContracts
{
    public interface IConversionsRepository
    {
        Task<List<Conversions>> GetAll();
        void SaveConversionsInFile(List<Conversions> list);
    }
}
