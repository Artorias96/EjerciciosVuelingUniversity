using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option7Screen
    {
        public void Start(List<Team> Teams, List<Task> TasksList)
        {
            Console.Clear();

            bool exit = false;
            do
            {
                Console.WriteLine("List of the task Assigneds: (select Id number)");

                foreach (var item in TasksList.Where(e => e.assigned == true))
                {
                    Console.WriteLine($"Id Tasks assigneds: {item.IdTask} \n" +
                        $"Task Descripton: {item.Description}");
                }

                var answerTaskAssigned = Convert.ToInt32(Console.ReadLine());

                if (answerTaskAssigned == 0)
                {
                    Console.WriteLine("Error, the number dosen´t exists");
                    break;
                }

                Task taskassigned = TasksList.FirstOrDefault(e => e.IdTask == answerTaskAssigned);

                Console.WriteLine("Select the team by the team name: ");

                foreach (var item in Teams)
                {
                    Console.WriteLine($"Team: {item.TeamName}");
                }

                var answerTeamTask = Console.ReadLine();

                if (answerTeamTask == null)
                {
                    Console.WriteLine("Please entry a real name");
                    break;
                }

                Team teamTaskAssigned = Teams.FirstOrDefault(e => e.TeamName == answerTeamTask);

                teamTaskAssigned.taskInTeam.Add(taskassigned);

                taskassigned.TeamTask = teamTaskAssigned;


                Console.WriteLine($"Team: {teamTaskAssigned.TeamName}");

                Console.WriteLine($"----------Task Description Selected for {teamTaskAssigned.TeamName} ----------");

                taskassigned.ShowValues();

                exit = true;

            } while (!exit);
        }
    }
}
