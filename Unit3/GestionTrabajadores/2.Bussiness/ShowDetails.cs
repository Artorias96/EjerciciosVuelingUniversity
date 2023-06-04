using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Bussiness
{
    public class ShowDetails
    {

        public void ShowTeamNames(List<Team> Teams)
        {
            Console.Clear();
            Console.WriteLine($"List of all Team names: ");

            foreach (var item in Teams)
            {
                Console.WriteLine($"Nombre del equipo: {item.TeamName}\n");
            }
        }

        public void ShowUnassignedTask(List<Task> TasksList)
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
