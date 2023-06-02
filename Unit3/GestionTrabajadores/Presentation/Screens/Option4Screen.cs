using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option4Screen
    {
        public void Start(List<Team> Teams)
        {
            Console.Clear();
            Console.WriteLine($"List of all Team names: ");

            foreach (var item in Teams)
            {
                Console.WriteLine($"Nombre del equipo: {item.TeamName}\n");
            }
        }
    }
}
