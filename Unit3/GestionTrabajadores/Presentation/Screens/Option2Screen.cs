using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option2Screen
    {
        public void Start(List<Team> Teams, Team team)
        {
            Console.Clear();
            Console.WriteLine("Introduce the name of the team you want to add");
            string nameOfTeam = Console.ReadLine();
            team = new Team(nameOfTeam);
            Teams.Add(team);

            Console.WriteLine($"Team With Name: {team.TeamName} Added succesfully");
        }
    }
}
