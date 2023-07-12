using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class TotalTravelCost
    {
		public decimal TotalAmount { get; set; }
		public decimal PriecesPerLunarDay { get; set; }
		public Taxes taxes { get; set; }

    }

	public class Taxes
	{
		public decimal OriginDefenseCost { get; set; }
		public decimal DestinationDefenseCost { get; set; }
		public decimal EliteDefenseCost { get; set;}
	}
	
}
