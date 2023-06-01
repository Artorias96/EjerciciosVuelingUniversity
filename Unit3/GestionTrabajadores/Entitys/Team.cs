using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class Team
    {
        //it worker tiene que ser manager
        public ITWorker Manager { get; set; }
        //lista itworker
        public List<ITWorker> Technicians { get; set; }

        public List<ITWorker> workersInTeam { get; set; }

        public List<Task > taskInTeam { get; set; }

        public string TeamName { get; set; }

        public Team(string nameTeam)
        {
            TeamName = nameTeam;
        }

    }
}
