using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class Team
    {
        
        public ITWorker Manager { get; set; }
       
        public List<ITWorker> Technicians { get; set; } = new List<ITWorker>();
                                                                                    //Si no inicializaba la lista me daba error de referencia de objeto
        public List<ITWorker> workersInTeam { get; set; } = new List<ITWorker>();

        public List<Task> taskInTeam { get; set; } = new List<Task>();

        public string TeamName { get; set; }

        public Team(string nameTeam)
        {
            TeamName = nameTeam;
        }

    }
}
