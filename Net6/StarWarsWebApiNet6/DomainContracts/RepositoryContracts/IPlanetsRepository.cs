using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.RepositoryContracts
{
    public interface IPlanetsRepository
    {
        Task<List<Planets>> GetAllPlanets();
        void SavePlanetsInFile(List<Planets> listOfConversions);
    }
}
