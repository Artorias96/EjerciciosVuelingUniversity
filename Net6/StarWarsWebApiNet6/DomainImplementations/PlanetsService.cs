using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainContracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainImplementations
{
    public class PlanetsService : IPlanetsService
    {
        private readonly IPlanetsRepository _planetsRepository;
        private readonly IDistancePlanetsRepository _distancePlanetsRepository;
        private readonly IRebelPercentageRepository _rebelPercentageRepository;
        private readonly IPricePerYearRepository _pricePerYearRepository;
        private readonly ICacheRepository _cacheRepository;

        public PlanetsService(IPlanetsRepository planetsRepository, IDistancePlanetsRepository distancePlanetsRepository, IRebelPercentageRepository rebelPercentageRepository, IPricePerYearRepository pricePerYearRepository, ICacheRepository cacheRepository)
        {
            _planetsRepository = planetsRepository;
            _distancePlanetsRepository = distancePlanetsRepository;
            _rebelPercentageRepository = rebelPercentageRepository;
            _pricePerYearRepository = pricePerYearRepository;
            _cacheRepository = cacheRepository;
        }

        public async Task <List<PlanetsTravelInfo>> GetAllPlanetsDistances()
        {
            // Antes de obtener los carros, verifica si hay una caché válida y la utiliza

            var ElementInfoList = _cacheRepository.GetCache<List<PlanetsTravelInfo>>("key");
            if (ElementInfoList != null)
            {
                return ElementInfoList;
            }

            List<Planets> planetsList = await _planetsRepository.GetAllPlanets();
            

            return await CalculateDistancePlanets(planetsList);
        }

        public async Task<TotalTravelCost> GetTravelCost(PlanetsTravel planetsTravel)
        {

            //var ElementInfoList = _cacheRepository.GetCache<List<PlanetsTravelInfo>>("key");
            //if (ElementInfoList != null)
            //{
            //    return ElementInfoList;
            //}

            TotalTravelCost totalTravelCost = new TotalTravelCost();

            List<Planets> planetsList = await _planetsRepository.GetAllPlanets();

            Planets planetOrigin = planetsList.First(x => x.PlanetName == planetsTravel.origin);
            Planets planetDestination = planetsList.First(x => x.PlanetName == planetsTravel.destination);

            List<PlanetsTravelInfo>  listPlanetsTravels = await CalculateDistancePlanets(planetsList);

             PlanetsTravelInfo planetsTravelInfo = listPlanetsTravels.FirstOrDefault(x => x.Origin == planetOrigin.PlanetName && x.Destination == planetDestination.PlanetName);

            if(planetsTravelInfo == null)
            {
                planetsTravelInfo = listPlanetsTravels.First(x => x.Origin == planetDestination.PlanetName && x.Destination == planetOrigin.PlanetName);
            }

            PricePerYear pricePerYear = await _pricePerYearRepository.GetPricePerYear();

            decimal costTravelPerLunarYear = (planetsTravelInfo.Distance / 100) * pricePerYear.PrieceForLunarYear;

            List<RebelPercentage> rebelPercentageList = await _rebelPercentageRepository.GetAllRebelPercentage();

            RebelPercentage planetOriginrebelPercentage = rebelPercentageList.FirstOrDefault(x => x.PlanetName == planetOrigin.PlanetName);
            RebelPercentage planetDestinationRebelPercentage = rebelPercentageList.FirstOrDefault(x => x.PlanetName == planetDestination.PlanetName);

            
            decimal originaPlanetSecurityCost = costTravelPerLunarYear * planetOriginrebelPercentage.RebelPercent / 100;
            
            decimal destinationPlanetSecurityCost = costTravelPerLunarYear * planetDestinationRebelPercentage.RebelPercent / 100;

            decimal defenseCost = 0;
            if (planetOriginrebelPercentage.RebelPercent + planetDestinationRebelPercentage.RebelPercent >= 50)
            {
                defenseCost = costTravelPerLunarYear * (originaPlanetSecurityCost + destinationPlanetSecurityCost) / 100;

                costTravelPerLunarYear += defenseCost;
            }
            //Precio total es distancia *precio dia lunar y suma de procentajes en defensa y se calculan
            decimal totalPrice = (planetsTravelInfo.Distance * pricePerYear.PrieceForLunarYear) + (originaPlanetSecurityCost + destinationPlanetSecurityCost);

            TotalTravelCost travelInfo = new TotalTravelCost()
            {
                TotalAmount = totalPrice,
                PriecesPerLunarDay = totalPrice / 100,
                taxes = new Taxes()
                {
                    DestinationDefenseCost = destinationPlanetSecurityCost,
                    OriginDefenseCost = originaPlanetSecurityCost,
                    EliteDefenseCost = defenseCost
                }
            };

            return (travelInfo);

        }

        private async Task<List<PlanetsTravelInfo>> CalculateDistancePlanets(List<Planets> planetsList)
        {
            DistancePlanets distancePlanets = await _distancePlanetsRepository.GetAllDistancePlanets();
            List<RebelPercentage> rebelPercentageList = await _rebelPercentageRepository.GetAllRebelPercentage();
            PricePerYear pricePerYear = await _pricePerYearRepository.GetPricePerYear();
            
            SaveDataInLocalFiles(planetsList, pricePerYear, rebelPercentageList, distancePlanets);

            decimal totalPlanetCost = 0;

            var planetDistanceList = new List<PlanetsTravelInfo>();

            foreach (var key in distancePlanets.Distances.Keys)
            {

                foreach (var item in distancePlanets.Distances[key])
                {
                    decimal itemCost = item.LunarYears * 100;

                    totalPlanetCost += itemCost;

                    PlanetsTravelInfo planetDistance = new PlanetsTravelInfo()
                    {
                        Origin = planetsList.First(x => x.Code == key).PlanetName,
                        Destination = planetsList.First(x => x.Code == item.Code).PlanetName,
                        Distance = totalPlanetCost
                    };

                    planetDistanceList.Add(planetDistance);
                }
            }
            _cacheRepository.SetCache<List<PlanetsTravelInfo>>("key", planetDistanceList);

            return planetDistanceList;

            
        }

        private void SaveDataInLocalFiles(List<Planets> planetsList, PricePerYear pricePerYear, List<RebelPercentage> rebelPercentageList, DistancePlanets distancePlanets)
        {
            _planetsRepository.SavePlanetsInFile(planetsList);
            _pricePerYearRepository.SavePricePerYearInFile(pricePerYear);
            _rebelPercentageRepository.SaveRebelPercentageInFile(rebelPercentageList);
            _distancePlanetsRepository.SaveDistancePlanetsInFile(distancePlanets);
        }
    }
}
