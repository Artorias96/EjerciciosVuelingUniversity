using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class Planets
    {
        public string PlanetName { get; set; }

        public string Code { get; set; }

        public string Sector { get; set; }
    }
}
