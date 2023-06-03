using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option7Screen
    {
        Assigneds assignedAs = new Assigneds();
        public void Start(List<Team> Teams, List<Task> TasksList)
        {
            assignedAs.AssignedsTaskByTeam(Teams, TasksList);
        }
    }
}
