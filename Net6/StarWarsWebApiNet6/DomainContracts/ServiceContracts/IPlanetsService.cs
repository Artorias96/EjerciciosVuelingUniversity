using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.ServiceContracts
{
    public interface IPlanetsService
    {
        Task<List<PlanetsTravelInfo>> GetAllPlanetsDistances();
        Task<TotalTravelCost> GetTravelCost(PlanetsTravel planetsTravel);
    }
}
