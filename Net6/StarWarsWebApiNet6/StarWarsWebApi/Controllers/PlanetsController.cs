using DomainContracts.DomainEntities;
using DomainContracts.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsWebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace StarWarsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetsService _planetsService;

        public PlanetsController(IPlanetsService planetsService)
        {
            _planetsService = planetsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConversions()
        {
            List<PlanetsTravelInfo> distancePlanetsList = await _planetsService.GetAllPlanetsDistances();

            List<PlanetsTravelInfoModel> listToShow = new List<PlanetsTravelInfoModel>();

            listToShow = distancePlanetsList.Select(dataFromJson => new PlanetsTravelInfoModel
            {
                Origin = dataFromJson.Origin,
                Destination = dataFromJson.Destination,
                Distance = dataFromJson.Distance
            }).ToList();

            return Ok(listToShow);
        }

        [HttpPost]
        public async Task<IActionResult> GetPriceTravels([Required]PlanetsTravelModel planetsTravelModel)
        {
            PlanetsTravel planetsTravel = new PlanetsTravel()
            {
                destination = planetsTravelModel.destination,
                origin = planetsTravelModel.origin,
            };

            TotalTravelCost distancePlanetsList = await _planetsService.GetTravelCost(planetsTravel);

            TotalTravelCostModel totalTravelCostModel = new TotalTravelCostModel();

            MapToModel(distancePlanetsList);

            return Ok(distancePlanetsList);
        }

            private TotalTravelCostModel MapToModel(TotalTravelCost totalTravelCost)
            {
                var totalTravelCostModel = new TotalTravelCostModel();

                totalTravelCostModel.TotalAmount = Math.Round(totalTravelCost.TotalAmount,2);
                totalTravelCostModel.PriecesPerLunarDay = Math.Round(totalTravelCost.PriecesPerLunarDay,2);

                totalTravelCostModel.taxes = new TaxesModel();
                totalTravelCostModel.taxes.OriginDefenseCost = Math.Round(totalTravelCost.taxes.OriginDefenseCost,2);
                totalTravelCostModel.taxes.DestinationDefenseCost = Math.Round(totalTravelCost.taxes.DestinationDefenseCost,2);
                totalTravelCostModel.taxes.EliteDefenseCost = Math.Round(totalTravelCost.taxes.EliteDefenseCost,2);

                return totalTravelCostModel;
            }
        
    }
}
