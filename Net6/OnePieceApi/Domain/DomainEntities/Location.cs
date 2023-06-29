using Domain.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool Validate()
        {
            return IdValidator.Validate(Id) && Name.Length == 2;
        }
    }
}
