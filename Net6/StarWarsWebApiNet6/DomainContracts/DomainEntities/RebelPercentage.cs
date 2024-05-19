using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class RebelPercentage
    {
        public string PlanetName { get; set; }

        public decimal RebelPercent { get; set; }
    }
}
