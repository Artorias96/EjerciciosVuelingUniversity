using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option6Screen
    {
        ShowDetails details = new ShowDetails();
        public void Start(List<Task> TasksList)
        {
            details.ShowUnassignedTask(TasksList);           
        }
    }
}
