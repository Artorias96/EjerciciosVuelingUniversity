using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Agregates
{
    public class MusicianList
    {
        public List<MusiciansInfo> musicianList { get; set; } = new List<MusiciansInfo>();

        public List<MusiciansInfo> FilterByNotContainedInNameList(List<string> names)
        {
            return musicianList.Where(x => !names.Contains(x.Name)).ToList();        
        }

        public List<MusiciansInfo> FilterOrderedByRoleCountAscending(string role)
        {
            return musicianList.Where(x => x.RoleList.Contains(role.ToLower())).OrderBy(x => x.RoleList.Count).ToList();
        }
    }
}
