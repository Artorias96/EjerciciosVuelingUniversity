using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.RepositoryContracts
{
    public interface IRebelPercentageRepository
    {
        Task<List<RebelPercentage>> GetAllRebelPercentage();
        void SaveRebelPercentageInFile(List<RebelPercentage> listOfConversions);
    }
}
