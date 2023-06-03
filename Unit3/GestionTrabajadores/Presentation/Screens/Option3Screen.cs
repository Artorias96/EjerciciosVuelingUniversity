using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option3Screen
    {
        Registers register = new Registers();

        public void Start(Task task, List<Task> TasksList)
        {
            register.RegisterNewTask(task, TasksList);
        }
    }
}
