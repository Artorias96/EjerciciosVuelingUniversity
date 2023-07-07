using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class UnavaiableDaysInfo
    {

        public string Name { get; set; } = string.Empty;


        public List<DateTime> UnavaiableDays { get; set; } = new List<DateTime>();
    }
}
