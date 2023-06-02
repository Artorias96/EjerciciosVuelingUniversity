using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option6Screen
    {
        public void Start(List<Task> TasksList)
        {
            Console.Clear();
            Console.WriteLine("Unassigned Tasks ");

            foreach (var item in TasksList.Where(e => e.assigned == false))
            {
                Console.WriteLine($"Description: {item.Description} \n" +
                    $"Tech: {item.Technology}\n" +
                    $"Task Id: {item.IdTask}");
            }
        }
    }
}
