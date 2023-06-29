using Domain.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<string> locationIdList { get; set; }

        public bool Validate()
        {
            return IdValidator.Validate(Id) && Name.Length <= 50 && locationIdList.Count > 0;
        }
    }
}
