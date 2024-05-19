using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class DistancePlanets
    {
        public Dictionary<string, List<PlanetInfo>> Distances { get; set; }
    }

    public class PlanetInfo
    {

        public string Code { get; set; }

        public decimal LunarYears { get; set; }

    }
}
