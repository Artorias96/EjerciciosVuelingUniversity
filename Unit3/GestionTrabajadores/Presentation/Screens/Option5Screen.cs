using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option5Screen
    {
        Assigneds assignedAs = new Assigneds();
        public void Start(List<Team> Teams, List<ITWorker> ItWorkersList)
        {
            assignedAs.AssignWorkerByTeam(Teams, ItWorkersList);
        }
    }
}
