using Crosscutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class Stay
    {
        public string? LocationId { get; set; }

        public DateTime ArrivalDate{ get; set; }

        public DateTime LeaveDate { get; set; }

        public bool Validate()
        {
            return LocationId.Length == 2 && LocationId.ToUpper() == LocationId;
        }
    }
}
