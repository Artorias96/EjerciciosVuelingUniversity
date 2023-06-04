using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class Team
    {
        public Team(string teamName)
        {
            TeamName = teamName;
        }

        public int WorkerIdManager { get; set; }
       
        public List<int> Technicians { get; set; }

        public string TeamName { get; set; }
    }


}
