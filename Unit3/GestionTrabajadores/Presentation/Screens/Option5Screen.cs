using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option5Screen
    {
        public void Start(List<Team> Teams, List<ITWorker> ItWorkersList)
        {
            Console.Clear();
            bool exit = false;
            do
            {
                
            Console.WriteLine("Write the Name of the Team: ");

            foreach (var item in Teams)
            {
                Console.WriteLine($"Name Team: {item.TeamName}");

            }

            var answerTeam = (Console.ReadLine());

            if (answerTeam == null)
            {
                Console.WriteLine("Please entry a real name");
                break;
            }

            Team teamname = Teams.FirstOrDefault(e => e.TeamName == answerTeam);

            teamname.TeamName = answerTeam;

            Console.WriteLine("Select the Worker by Id");

            foreach (var item in ItWorkersList)
            {
                Console.WriteLine($"Worker Id: {item.ItWorkerId}");
            }

            var answerWorkerId = Convert.ToInt32(Console.ReadLine());

            if (answerWorkerId == 0)
            {
                Console.WriteLine("Error, choose the number of the worker");
                break;
            }

            ITWorker workerid = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWorkerId);

            workerid.ItWorkerId = answerWorkerId;

            workerid.TeamWorker = teamname;

            teamname.workersInTeam.Add(workerid);

            Console.WriteLine($"Team: {teamname.TeamName}");

                Console.WriteLine("----------Worker Selected Description----------");

                workerid.ShowValues();

                exit = true;

            } while (!exit);
        }
    }
}
