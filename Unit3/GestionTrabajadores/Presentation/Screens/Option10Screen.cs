using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option10Screen
    {
        Assigneds assignedAs = new Assigneds();
        public void Start(List<Task> TasksList, List<ITWorker> ItWorkersList)
        {
            assignedAs.AssignTaskToWorker(TasksList, ItWorkersList);
        }
    }
}
