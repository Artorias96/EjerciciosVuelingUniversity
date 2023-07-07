using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class MusiciansInfo
    {
        public string Name { get; set; } = string.Empty;

        public List<string> RoleList { get; set; } = new List<string>();
    }
}
