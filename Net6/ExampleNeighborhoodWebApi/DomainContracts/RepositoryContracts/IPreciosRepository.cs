using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.RepositoryContracts
{
    public interface IPreciosRepository
    {
        Task<Precios> GetAll();
        void SavePreciosInFile(Precios listOfConversions);
    }
}
