﻿using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class LocationList
    {
        public List<Location> List { get; set; }
    }
}
