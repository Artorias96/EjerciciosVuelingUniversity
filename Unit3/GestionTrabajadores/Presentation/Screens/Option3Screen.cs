using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option3Screen
    {

        public void Start(Task task, List<Task> TasksList)
        {
            Console.Clear();
            Console.WriteLine("Introduce description of the new task");
            string description = Console.ReadLine();

            Console.WriteLine("Introduce the technology to use");
            string technology = Console.ReadLine();

            Console.WriteLine("Introduce state of task \n 1-ToDo \n 2-Doing \n 3-Done");
            var status = Convert.ToInt32(Console.ReadLine());

            task = new Task(description, technology, (Status)status);

            TasksList.Add(task);

            Console.WriteLine($"Task With Id: {task.IdTask} Added succesfully");
        }
    }
}
