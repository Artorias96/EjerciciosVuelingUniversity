﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class PlanetsTravelInfo
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Distance { get; set; }
    }
}
