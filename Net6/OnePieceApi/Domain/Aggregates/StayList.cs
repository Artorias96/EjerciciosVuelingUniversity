using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class StayList
    {
        public List<Stay> List { get; set; }

        public bool ValidateList()
        {
            return List.All(x => x.Validate());
        }

        public int RemoveInvalidElements()
        {
            int invalidElements = 0;    
            List<Stay> filteredList = new();

            foreach (var stay in List)
            {
                if (stay.Validate())
                {
                    filteredList.Add(stay);
                }
                invalidElements++;
            }

            List = filteredList;

            return invalidElements;
        }
    }
}
