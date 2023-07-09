using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class Conversions
    {
        public string From { get; set; }

        public string To { get; set; }

        public decimal rate { get; set; }
    }
}
